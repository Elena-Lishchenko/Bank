using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Transaction.Model
{
	public class Customer
	{
		public Customer()
		{
			Accounts = new Collection<Account>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		public string Address { get; set; }

		[Phone]
		public string Phone { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public ICollection<Account> Accounts { get; set; }
	}
}
