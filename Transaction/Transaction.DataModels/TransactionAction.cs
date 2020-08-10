using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class TransactionAction
	{
		public int Id { get; set; }

		[Required]
		[StringLength(60)]
		public string Description { get; set; }
	}
}
