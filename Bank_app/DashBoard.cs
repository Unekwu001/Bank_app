using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class DashBoard : Login
	{
		ArrayList firstAccountCreated = new ArrayList() { cusFullname, cusAccountType, cusAccountNo, 0 };
 
		 

		public void ShowMenu()
		{

			
			Console.WriteLine($"---{(string)firstAccountCreated[0]}'s--DASHBOARD------\n");
			Console.WriteLine($"Welcome, dear {(string)firstAccountCreated[0]}.\nWhat would you like to do today ?");
			Console.WriteLine(">Press 1 Create Account");
			Console.WriteLine(">Press 2 to Deposit");
			Console.WriteLine(">Press 3 to Withdraw");
			Console.WriteLine(">Press 4 Transfer");
			Console.WriteLine("Press 5 to get balance");
			Console.WriteLine("Press 6 to get your Statement");
			Console.WriteLine("Press 7 to Logout\n\n");
			Console.Write("Select an option: ");
			do
			{
				string choice = Console.ReadLine();
				if (choice == "1") { Create2ndAccount(); }
				else if (choice == "2") { Deposit(); }
				else if (choice == "3") { Withdraw(); }
				else if (choice == "4") { Transfer(); }
				else if (choice == "5") { GetBalance(); }
				else if (choice == "6") { GetStatement(); }
				else if (choice == "5") { LogOut(); }
				if (int.Parse(choice) > 7 || int.Parse(choice) < 1)
				{
					Console.WriteLine("Oops, the selected Number is out of range.");
					ShowMenu();
				}
			} while (!int.TryParse(choice, out _) || int.Parse(choice) > 7 || int.Parse(choice) < 1);

		}
		private void Create2ndAccount()
		{
			Console.Clear();
			string accNo = "";
			decimal accBal = 0;
			string accType = "";


			void selectAccType()
			{
			
				Console.WriteLine(" Please Enter your desired account type\n");
				Console.WriteLine(">  Press 1 for savings account\n>  Press 2 for current account  ");
				string input = Console.ReadLine();
				do {
					if (input == "1")
					{
						accType += "savings";
						Console.WriteLine("You need to deposit at least 1000 naira to open such an account");
						Console.Write("Please enter an amount greater or equal to 1000 naira: ");
						string enteredAmount = Console.ReadLine();
						if (enteredAmount == "1000" || int.Parse(enteredAmount) >= 1000)
						{
							decimal cleanAmount = decimal.Parse(enteredAmount);
							accBal += cleanAmount;
							Console.WriteLine($"You have successfully added {cleanAmount}");
						}
						else
						{
							Console.WriteLine($"Invalid amount!. You need to enter an amount greater then 1000 naira. ");
							Console.WriteLine($"Processed Restarted !");
							selectAccType();
						}

					}
					else if (input == "2")
					{
						accType = "current";
					}
					else
					{
						Console.Clear();
						Console.WriteLine("You have entered an incorrect command. Please Retry");
						Create2ndAccount();
					}
				}while (!int.TryParse(input,out _) ||  int.Parse(input) != 2 || int.Parse(input) != 1);
			}

			void GenerateAnotherAccountNo()
			{
			Random random = new Random();
			var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
			accNo += i.ToString();
			Console.WriteLine($"An account Number has been generated for you!>>{accNo}");
			}


			void SaveCreatedAcc()
			{
			ArrayList newAccount = new ArrayList() { cusFullname, accType, accNo,accBal };
			firstAccountCreated.Add(newAccount);
			}
			
			 
			 
		}

		

		





		
	}
}

 
			 
