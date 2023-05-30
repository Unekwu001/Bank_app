using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Transactions
	{
		//Deposit fields
		string AccountToDepositTo;
		string AmountToSend;
		decimal CleanAmountToSend;


		//Withdraw fields
		string AmountToWithdraw;
		string AccountToWithdrawFrom;
		decimal CleanAmountToWithdraw;



		public void Deposit()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.WriteLine("\nHere are your accounts above.\n Type in the account number you want to send money to.");
			AccountToDepositTo = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to send");
			AmountToSend = Console.ReadLine();
			CleanAmountToSend = int.Parse(AmountToSend);

			foreach(Account acc in DashBoard.accounts)
			{
				if(!acc.AccountNumber.Contains(AccountToDepositTo))
				{
					Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number\n");
					Deposit();
				}
				else if (acc.AccountNumber == AccountToDepositTo)
				{
					acc.Balance += CleanAmountToSend;
					Console.WriteLine($"You have successfully deposited {CleanAmountToSend} into your account with account number {AccountToDepositTo}");
					dash.PromptToViewAccount();
				}
			}
		}




		public void Withdraw()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.WriteLine("\nHere are your accounts above.\n Type in the account number you want to WithDraw from.");
			AccountToWithdrawFrom = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to Withdraw");
			AmountToWithdraw = Console.ReadLine();
			CleanAmountToWithdraw = int.Parse(AmountToWithdraw);

			foreach (Account acc in DashBoard.accounts)
			{
				if (!acc.AccountNumber.Contains(AccountToWithdrawFrom))
				{
					Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number\n");
					Withdraw();
				}
				else if (acc.AccountNumber == AccountToWithdrawFrom)
				{
					acc.Balance -= CleanAmountToWithdraw;
					Console.WriteLine($"You have successfully Withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
					dash.PromptToViewAccount();
				}
			}

		}


	}
}
