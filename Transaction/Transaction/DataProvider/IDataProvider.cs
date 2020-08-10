using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Model;

namespace Transaction.DataProvider
{
	public interface IDataProvider
	{
		Task<IEnumerable<Bank>> GetBanks();
		Task<Bank> GetBankWithAccounts(int bankId);
		Task<IEnumerable<Bank>> GetAllBanks();
		Task CreateTransaction(BankTransaction transaction);
	}
}
