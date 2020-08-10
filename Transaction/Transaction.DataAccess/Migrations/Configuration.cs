namespace Transaction.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;
	using System.Linq;
	using Transaction.Common;
	using Transaction.Model;

	internal sealed class Configuration : DbMigrationsConfiguration<Transaction.DataAccess.BankTransactionDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Transaction.DataAccess.BankTransactionDbContext context)
		{
			context.AccountTypes.AddOrUpdate(
				a => a.Name,
				new AccountType { Name = Constants.AccountTypeNames.LegalEntity },
				new AccountType { Name = Constants.AccountTypeNames.Individual },
				new AccountType { Name = Constants.AccountTypeNames.NonResident }
				);


			context.BankTransactionTypes.AddOrUpdate(
				a => a.Name,
				new BankTransactionType { Name = Constants.BankTransactionTypeNames.Internal },
				new BankTransactionType { Name = Constants.BankTransactionTypeNames.External }
				);

			context.TransactionActions.AddOrUpdate(
				a => a.Description,
				new TransactionAction { Description = Constants.TransactionActionDescriptions.CreateModal },
				new TransactionAction { Description = Constants.TransactionActionDescriptions.SendDataToPartner },
				new TransactionAction { Description = Constants.TransactionActionDescriptions.SendDataToTax },
				new TransactionAction { Description = Constants.TransactionActionDescriptions.SendEnglishPaymentDocuments },
				new TransactionAction { Description = Constants.TransactionActionDescriptions.SendPaymentDocuments },
				new TransactionAction { Description = Constants.TransactionActionDescriptions.Sms }
				);

			context.Banks.AddOrUpdate(
				a => a.Name,
				new Bank { Name = Constants.BankNames.Alfabank },
				new Bank { Name = Constants.BankNames.Sberbank },
				new Bank { Name = Constants.BankNames.Vtb }
				);

			context.Customers.AddOrUpdate(
				a => a.Name,
				new Customer { Name = "Customer" }
				);

			context.SaveChanges();

			context.BankRates.AddOrUpdate(
				a => new { a.BankTransactionTypeId, a.BankId },
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Alfabank),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.Internal),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.CreateModal),
					Value = 1
				},
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Alfabank),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.External),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.CreateModal),
					Value = 2.5
				},
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Vtb),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.Internal),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.SendDataToPartner),
					Value = 0
				},
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Vtb),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.External),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.SendDataToPartner),
					Value = 2
				},
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Sberbank),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.Internal),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.SendDataToTax),
					Value = 0
				},
				new BankRate
				{
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Sberbank),
					BankTransactionType = context.BankTransactionTypes.FirstOrDefault(t => t.Name == Constants.BankTransactionTypeNames.External),
					TransactionAction = context.TransactionActions.FirstOrDefault(a => a.Description == Constants.TransactionActionDescriptions.SendDataToTax),
					Value = 1
				});

			context.StandartRules.AddOrUpdate(
				a => a.SenderAccountTypeId,
				new StandartRule
				{
					SenderAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					TransactionAction = context.TransactionActions.FirstOrDefault(b => b.Description == Constants.TransactionActionDescriptions.Sms)
				},
				new StandartRule
				{
					SenderAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					TransactionAction = context.TransactionActions.FirstOrDefault(b => b.Description == Constants.TransactionActionDescriptions.SendPaymentDocuments)
				},
				new StandartRule
				{
					SenderAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					TransactionAction = context.TransactionActions.FirstOrDefault(b => b.Description == Constants.TransactionActionDescriptions.SendEnglishPaymentDocuments)
				});
			context.Customers.AddOrUpdate(
				new Customer
				{
					Name = "Jack"
				},
				new Customer
				{
					Name = "Jinna"
				});

			context.SaveChanges();

			context.StandartRates.AddOrUpdate(
				a => new { a.StandartRuleId, a.ReceiverAccountTypeId },
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual)),
					Value = 0
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual)),
					Value = 0
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual)),
					Value = 0
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity)),
					Value = 2
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity)),
					Value = 3
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity)),
					Value = 4
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident)),
					Value = 4
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident)),
					Value = 6
				},
				new StandartRate
				{
					ReceiverAccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					StandartRuleType = context.StandartRules.FirstOrDefault(r => r.SenderAccountType == context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident)),
					Value = 6
				});

			context.Accounts.AddOrUpdate(
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Alfabank),
					Customer = context.Customers.First(),
					Balance = 100
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Sberbank),
					Customer = context.Customers.First(),
					Balance = 200
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Vtb),
					Customer = context.Customers.First(),
					Balance = 300
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.Individual),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Sberbank),
					Customer = context.Customers.First(),
					Balance = 400
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Alfabank),
					Customer = context.Customers.First(),
					Balance = 100
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Sberbank),
					Customer = context.Customers.First(),
					Balance = 200
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.LegalEntity),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Vtb),
					Customer = context.Customers.First(),
					Balance = 300
				},
				new Account
				{
					AccountType = context.AccountTypes.FirstOrDefault(b => b.Name == Constants.AccountTypeNames.NonResident),
					Bank = context.Banks.FirstOrDefault(b => b.Name == Constants.BankNames.Vtb),
					Customer = context.Customers.First(),
					Balance = 400
				});
		}
	}
}
