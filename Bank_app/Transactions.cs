using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Transactions
	{
		//Deposit fields
		string AccountToDepositTo;
		string AmountToDeposit;
		decimal CleanAmountToDeposit;


		//Withdraw fields
		string AmountToWithdraw;
		string AccountToWithdrawFrom;
		decimal CleanAmountToWithdraw;


		//transfer fields
		string AccountToTransferTo;
		string AccountToTransferFrom;
		decimal CleanAmountToTransfer;




		public void Deposit()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.Write("Type in the account number you want to send money to.>>");
			AccountToDepositTo = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to send");
			AmountToDeposit = Console.ReadLine().Trim();
			CleanAmountToDeposit = decimal.Parse(AmountToDeposit);

			foreach (Account acc in DashBoard.accounts)
			{
				if (!acc.AccountNumber.Contains(AccountToDepositTo))
				{
					Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");
					Deposit();
				}
				else if (acc.AccountNumber == AccountToDepositTo)
				{
					acc.Balance += CleanAmountToDeposit;
					Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");
					dash.PromptToViewAccount();
				}
			}
		}





		public void Withdraw()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.WriteLine("Here are your accounts above.\n Type in the account number you want to WithDraw from.");
			AccountToWithdrawFrom = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to Withdraw");
			AmountToWithdraw = Console.ReadLine();
			CleanAmountToWithdraw = int.Parse(AmountToWithdraw);

			foreach (Account acc in DashBoard.accounts)
			{
				if (acc.AccountNumber.Contains(AccountToWithdrawFrom) && acc.AccountType == "savings" && acc.Balance <= 1000)
				{
					Console.Clear();
					Console.WriteLine("Unable to withdraw. There should be a minimum of 1000 naira in your savings account ");
					Withdraw();
				}
				else if (!acc.AccountNumber.Contains(AccountToWithdrawFrom))
				{

					Console.Clear();
					Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number\n");
					Withdraw();
				}
				else if (CleanAmountToWithdraw > acc.Balance)
				{
					Console.Clear();
					Console.WriteLine("Insufficient Funds!, Kindly try a lesser amount.");
					Withdraw();
				}
				else if (acc.AccountNumber == AccountToWithdrawFrom)
				{
					acc.Balance -= CleanAmountToWithdraw;
					Console.WriteLine($"You have successfully Withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
					dash.PromptToViewAccount();
				}
				else
				{
					Console.WriteLine("Oops!, kindly enter a valid amount.");
					Withdraw();
				}
			}
		}






		public void Transfer()
		{
<<<<<<< HEAD

			var dash = new DashBoard();
			dash.ShowAllAccount();
=======
 
			var dash = new DashBoard();
			dash.ShowAllAccount();
			Console.WriteLine("----------Transfers-----------");
			Console.Write("Enter the account number TRANSFER FROM:>> ");
			AccountToTransferFrom = Console.ReadLine();
 

			var dsh = new DashBoard();
			dsh.ShowAllAccount();
>>>>>>> 73abdabac2b9ea7ebe90e04ddd175a0ada97f50a
			Console.WriteLine("----------Transfers-----------");

			do
			{
				Console.Write("Enter the account number TRANSFER FROM:>> ");
				AccountToTransferFrom = Console.ReadLine();

				Console.Write("Enter the account you want to TRANSFER TO:>> ");
				AccountToTransferTo = Console.ReadLine();

				Console.WriteLine("Enter the amount you want to transfer:>> ");
				CleanAmountToTransfer = int.Parse(AmountToWithdraw);

			} while (!int.TryParse(AccountToTransferFrom,out _));

			foreach (Account acc in DashBoard.accounts)
			{
				if (acc.AccountNumber.Contains(AccountToTransferFrom) && acc.AccountNumber.Contains(AccountToTransferTo))
				{
					if (acc.AccountNumber == AccountToTransferFrom)
					{
						if (acc.Balance <= 1000 && acc.AccountType == "savings")
						{
							Console.WriteLine("Insufficient Funds to Transfer!");
							Transfer();
						}
						else if (acc.Balance > CleanAmountToTransfer && acc.AccountType == "current")
						{
							acc.Balance -= CleanAmountToWithdraw;
							Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
						}
					}
					if (acc.AccountNumber == AccountToTransferTo)
					{
						acc.Balance += CleanAmountToTransfer;
					}

					var das = new DashBoard();
					das.PromptToViewAccount();
				}

				else
				{
					Console.Clear();
					Console.WriteLine($"\n\nError in Transaction!");
					Transfer();
				}
			}
		}
	}
}
