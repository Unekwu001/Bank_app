using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class DashBoard : Login
	{
		string deposit { set; get; }
		string withdraw { set; get; }
		string checkbalance { set; get; }
		string transfer { set; get; }
		string getstatement { set; get; }


		public DashBoard()
		{
			deposit = deposit;
			withdraw = withdraw;
			checkbalance = checkbalance;
			transfer = transfer;
			getstatement = getstatement;
		}

		public string Deposit { get => deposit; set => deposit = value; }

		public void ShowMenu()
		{
			while (loggedInCustomer != null)
			{
				Console.WriteLine($"Welcome, {loggedInCustomer.fullname}!");
				Console.WriteLine(">Press 1 Create Account");
				Console.WriteLine(">Press 2 to Deposit");
				Console.WriteLine(">Press 3 to Withdraw");
				Console.WriteLine(">Press 4 Transfer");
				Console.WriteLine("Press 5 to get balance");
				Console.WriteLine("Press 6 to get your Statement");
				Console.WriteLine("Press 7 to Logout\n\n");
				Console.Write("Select an option: ");

				string choice = Console.ReadLine();

				//switch (choice)
				//{
				//	case "1":
				//		Create2ndAccount();
				//		break;
				//	case "2":
				//		Deposit();
				//		break;
				//	case "3":
				//		Withdraw();
			//			break;
				//	case "4":
				//		Transfer();
				//		break;
				//	case "5":
				//		GetBalance();
				//		break;
				//	case "6":
				//		GetStatement();
				//		break;
				//	case "7":
				//		Logout();
				//	break;
				//	default:
				//		Console.WriteLine("Invalid choice. Please try again.");
				//		break;
				//}
			}
		}
		private void Create2ndAccount()
		{

			void AccountType()
			{
				string accountType;
				Console.WriteLine(">  Press 1 to open a savings account\n>  Press 2 to open a current account  ");
				accountType = Console.ReadLine();

				string savings = "SAVINGS";
				string current = "CURRENT";

				if (accountType == "1")
				{
					accountType = savings;
				}
				else if (accountType == "2")
				{
					accountType = current;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("You have entered an incorrect command. Please Retry");
					AccountType();
				}
			}
			AccountType();

			void GenerateAccountNo()
			{
				string accountNo;
				Random random = new Random();
				var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
				accountNo = i.ToString();
			}
			GenerateAccountNo();


			void AddingNewAccount()
			{
				//Account existingAccount = Account.find(a => a.AccountNo == accountNo);
				//if (existingAccount != null)
				//{
				//	Console.WriteLine("Account number already exists. Account creation failed.");
				//	return;
				//}

			//	Account newAccount = new Account(accountNumber, accountType);
			//	loggedInCustomer.Accounts.Add(newAccount);

				Console.WriteLine("Account created successfully.");
			}
			AddingNewAccount();
		}

	}
}
