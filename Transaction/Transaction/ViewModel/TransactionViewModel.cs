using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transaction.ViewModel
{
	public class TransactionViewModel
	{
		public decimal Sum { get; set; }
		public int OperatorId { get; set; }
		public double BankRate { get; set; }
		public double StandartRate { get; set; }
		public BankViewModel Bank { get; set; }
		public AccountViewModel Sender { get; set; }
		public AccountViewModel Receiver { get; set; }
	}
}