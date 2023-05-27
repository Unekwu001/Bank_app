using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Account
	{
		public string AccountNumber { get; set; }
		public string AccountType { get; set; }
		public decimal Balance { get; set; }

		public Account(string accountNumber, string accountType)
		{
			AccountNumber = accountNumber;
			AccountType = accountType;
			Balance = 0;
		}
	}
}
