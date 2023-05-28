using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class RegisterCustomer:Program
	{
		// Fields
		string pick;
		public static string cusFullname = "";
		public static string cusEmail = "";
		public static string cusPassword = "";
		public static string cusAccountNo = "";
		public static string cusAccountType = "";
		 	 

		internal void Registration() //Registration method 
		{
			string press;
			Console.Clear();
			Console.WriteLine("Register to Shazam Bank\n");
			AccountType();
			Fullname();
			Email();
			Password();
			GenerateAccountNo();
			ShowMyRegistration();
			 
			
			do
			{
				Console.WriteLine("Congratulations on your account Opening Champ!\nDo you want to proceed to Login ? Y or N\n");
				press = Console.ReadLine();

				if (press == "y" || press == "Y")
				{
					GoToLogin();
				}
			}while (!int.TryParse(press, out _ ));

		}

		//Printing of the all registered Customers
		internal void ShowMyRegistration()
		{
				Console.WriteLine($"Name:    {cusFullname} ");
				Console.WriteLine($"Account Type:   {cusAccountType}");
				Console.WriteLine($"Account Number:   {cusAccountNo}");
				Console.WriteLine($"Email:    {cusEmail}");
				Console.WriteLine($"Password: Your password and other details has been sent to your email.\n\n");		
		}

		//---------------------------------------------------------------------------------------------------------------------------


		

		
		//-----------------------------------------------------------------------------------------------------------
		

		public void AccountType()
		{
			Console.WriteLine(" Please Enter your desired account type\n");
			Console.WriteLine(">  Press 1 for savings account\n>  Press 2 for current account  ");
			string input = Console.ReadLine();

			if (input == "1")
			{
				cusAccountType += "savings";
			}
			else if (input == "2")
			{
				cusAccountType += "current";
			}
			else
			{
				Console.Clear();
				Console.WriteLine("You have entered an incorrect command. Please Retry");
				AccountType();
			}
		}


		public void Fullname()
		{
			do// reading fullname from console
			{
				Console.Clear();
				Console.WriteLine("Please input your fullname to register");
				cusFullname = Console.ReadLine().ToUpper().Trim();
			}
			while (!Regex.IsMatch(cusFullname, namePattern));
		}


		public void Email()
		{
			do //reading email from console
			{
				Console.Clear();
				Console.WriteLine("Please input your email");
				cusEmail = Console.ReadLine();

			}
			while (!Regex.IsMatch(cusEmail, emailPattern));
		}


		public void Password()
		{
			do //reading password from console
			{
				Console.Clear();
				Console.WriteLine("Please input your password");
				cusPassword = Console.ReadLine();

			}
			while (!Regex.IsMatch(cusPassword, passwordPattern));
		}


		public void GenerateAccountNo()
		{
			Random random = new Random();
			var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
			cusAccountNo = i.ToString();
		}

		 
		public void GoToLogin()
		{	 
			var mylogin = new Login();
			mylogin.ApproveLogin();
		}

	}
}
