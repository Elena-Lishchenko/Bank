using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class Bank
	{
		public Bank()
		{
			Accounts = new Collection<Account>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		public string Description { get; set; }
		public ICollection<Account> Accounts { get; set; }
	}
}
