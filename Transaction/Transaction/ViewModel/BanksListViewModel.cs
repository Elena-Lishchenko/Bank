using System.Collections.Generic;

namespace Transaction.ViewModel
{
	public class BanksListViewModel
	{
		public BanksListViewModel()
		{
			Banks = new List<BankViewModel>();
		}

		public List<BankViewModel> Banks { get; set; }
		public int SelectedBankId { get; set; }
		public BankViewModel SelectedBank { get; set; }

	}
}