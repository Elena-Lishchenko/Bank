using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class StandartRule
	{
		public int Id { get; set; }

		[Required]
		public int SenderAccountTypeId { get; set; }

		[Required]
		public int TransactionActionId { get; set; }

		public AccountType SenderAccountType { get; set; }
		public TransactionAction TransactionAction { get; set; }
	}
}
