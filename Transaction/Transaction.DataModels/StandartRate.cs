using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class StandartRate
	{
		public int Id { get; set; }

		[Required]
		public int StandartRuleId { get; set; }

		[Required]
		public int ReceiverAccountTypeId { get; set; }

		[Required]
		public int Value { get; set; }

		public StandartRule StandartRuleType { get; set; }

		public AccountType ReceiverAccountType { get; set; }

	}
}
