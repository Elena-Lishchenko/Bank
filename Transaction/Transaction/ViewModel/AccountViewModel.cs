using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transaction.Model;

namespace Transaction.ViewModel
{
	public class AccountViewModel
	{
		public int Id { get; set; }

		public decimal Balance { get; set; }

		public AccountTypeViewModel AccountType { get; set; }
		public BankViewModel Bank { get; set; }
		public CustomerViewModel Customer { get; set; }

	}
}