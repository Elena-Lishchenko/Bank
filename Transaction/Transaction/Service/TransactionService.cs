using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transaction.DataProvider;
using Transaction.Model;
using Transaction.ViewModel;

namespace Transaction.Service
{
	public class TransactionService : ITransactionService
	{
		private IDataProvider _dataProvider;

		public TransactionService(IDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		public async Task<BanksListViewModel> GetBanksList()
		{
			var banksList = new List<BankViewModel>();
			var banks = await _dataProvider.GetBanks();
			foreach (var bank in banks)
			{
				banksList.Add(new BankViewModel
				{
					Id = bank.Id,
					Name = bank.Name
				});
			}
			return new BanksListViewModel
			{
				Banks = banksList
			};
		}

		public async Task<BankViewModel> GetBankAccountsList(int bankId)
		{
			var bank = await _dataProvider.GetBankWithAccounts(bankId);
			return MapBankToViewModel(bank);
		}

		public async Task CreateTransaction(TransactionViewModel transaction)
		{
			SetRates(transaction);
			BankTransaction model = MapTransaction(transaction);
			await _dataProvider.CreateTransaction(model);
		}

		private static void SetRates(TransactionViewModel transaction)
		{
			transaction.StandartRate = 1;
			transaction.BankRate = 1;
		}

		private static BankTransaction MapTransaction(TransactionViewModel transaction)
		{
			return new BankTransaction
			{
				OperatorId = transaction.OperatorId,
				SenderId = transaction.Sender.Id,
				ReceiverId = transaction.Receiver.Id,
				Sum = transaction.Sum,
				BankRate = transaction.BankRate,
				StandartRate = transaction.StandartRate,
				TransactionDate = DateTime.Now
			};
		}

		private static BankViewModel MapBankToViewModel(Bank bank)
		{
			var newBank = new BankViewModel
			{
				Id = bank.Id,
				Name = bank.Name
			};
			foreach (var account in bank.Accounts)
			{
				newBank.Accounts.Add(new AccountViewModel
				{
					Id = account.Id,
					AccountType = new AccountTypeViewModel
					{
						Id = account.AccountType.Id,
						Name = account.AccountType.Name
					},
					Customer = new CustomerViewModel
					{
						Id = account.CustomerId
					},
					Balance = account.Balance
				});
			}

			return newBank;
		}
	}
}