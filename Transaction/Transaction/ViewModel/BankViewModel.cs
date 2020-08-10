using System.Collections.Generic;

namespace Transaction.ViewModel
{
	public class BankViewModel
	{
		public int Id { get; set; }
		public BankViewModel()
		{
			Accounts = new List<AccountViewModel>();
		}

		public string Name { get; set; }
		public List<AccountViewModel> Accounts { get; set; }
	}
}