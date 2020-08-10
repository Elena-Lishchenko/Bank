using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class BankRate
	{
		public int Id { get; set; }

		[Required]
		public int BankId { get; set; }

		[Required]
		public int BankTransactionTypeId { get; set; }

		[Required]
		public int TransactionActionId { get; set; }

		[Required]
		public double Value { get; set; }

		public Bank Bank { get; set; }
		public BankTransactionType BankTransactionType { get; set; }
		public TransactionAction TransactionAction { get; set; }
	}
}
