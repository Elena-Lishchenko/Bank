using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Transaction.DataAccess;
using Transaction.Model;

namespace Transaction.DataProvider
{
	public class DBDataProvider :IDataProvider
	{
		public DBDataProvider(BankTransactionDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		private BankTransactionDbContext _dbContext;

		public async Task<IEnumerable<Bank>> GetBanks()
		{
			return await _dbContext.Banks.AsNoTracking().ToListAsync();
		}

		public async Task<Bank> GetBankWithAccounts(int bankId)
		{
			var bank = await _dbContext.Banks.SingleOrDefaultAsync(a => a.Id == bankId);
			await _dbContext.Entry(bank)
				.Collection(b => b.Accounts)
				.Query()
				.Include(a => a.AccountType)
				.ToListAsync();
			return bank;
		}

		public async Task<IEnumerable<Bank>> GetAllBanks()
		{
			return await _dbContext.Banks.AsNoTracking()
				.Include(b => b.Accounts.Select(a => a.AccountType))
				.ToListAsync();
		}

		public async Task CreateTransaction(BankTransaction transaction)
		{
			_dbContext.Transactions.Add(transaction);
			await _dbContext.SaveChangesAsync();
		}
	}
}