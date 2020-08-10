using System;
using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class BankTransactionType
	{
		public int Id { get; set; }

		[Required]
		[StringLength(15)]
		public string Name { get; set; }
	}
}
