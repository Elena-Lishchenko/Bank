using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Transaction.Model;

namespace Transaction.DataAccess
{
	public class BankTransactionDbContext: IdentityDbContext<Operator>
	{
		public BankTransactionDbContext()
			:base("Transaction")
		{
		}

		public DbSet<AccountType> AccountTypes { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<BankRate> BankRates { get; set; }
		public DbSet<StandartRule> StandartRules { get; set; }
		public DbSet<StandartRate> StandartRates { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<BankTransaction> Transactions { get; set; }
		public DbSet<BankTransactionType> BankTransactionTypes { get; set; }
		public DbSet<TransactionAction> TransactionActions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
			base.OnModelCreating(modelBuilder);


		}

		public static BankTransactionDbContext Create()
		{
			return new BankTransactionDbContext();
		}
	}
}
