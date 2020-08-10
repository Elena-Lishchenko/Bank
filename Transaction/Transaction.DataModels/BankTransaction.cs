using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class BankTransaction
	{
		public int Id { get; set; }

		[Required]
		public int SenderId { get; set; }

		[Required]
		public decimal Sum { get; set; }

		[Required]
		public int ReceiverId { get; set; }

		[Required]
		public double StandartRate { get; set; }

		[Required]
		public double BankRate { get; set; }

		[Required]
		public int OperatorId { get; set; }

		[Required]
		public System.DateTime TransactionDate { get; set; }

		public Account Sender { get; set; }
		public Account Receiver { get; set; }
		public Operator Operator { get; set; }
	}
}
