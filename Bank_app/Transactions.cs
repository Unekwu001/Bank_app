using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Transactions
	{
		string AccountToDepositTo;
		void Deposit()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();
			Console.WriteLine("\nHere are your accounts above.\n Type in the account number you want to send money to.");
			AccountToDepositTo = Console.ReadLine();

			
		}
	}
}
