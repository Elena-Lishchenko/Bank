using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class Account
	{
		public int Id { get; set; }

		[Required]
		public int BankId { get; set; }

		[Required]
		public int AccountTypeId { get; set; }

		[Required]
		public int CustomerId { get; set; }

		[Required]
		public decimal Balance { get; set; }

		public AccountType AccountType { get; set; }
		public Bank Bank { get; set; }
		public Customer Customer { get; set; }

	}
}
