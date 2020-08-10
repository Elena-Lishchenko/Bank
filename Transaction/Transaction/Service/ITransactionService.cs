using System.Threading.Tasks;
using Transaction.ViewModel;

namespace Transaction.Service
{
	public interface ITransactionService
	{
		Task<BanksListViewModel> GetBanksList();
		Task<BankViewModel> GetBankAccountsList(int bankId);
		Task CreateTransaction(TransactionViewModel transaction);
	}
}
