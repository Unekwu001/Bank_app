﻿using Microsoft.Win32;
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
	internal class RegisterCustomer
	{
		// Fields
		public readonly string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
		public readonly string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
		public readonly string namePattern = @"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$";
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
			Fullname();
			Email();
			Password();
			GenerateAccountNo();
			AccountType();
			ShowMyRegistration();

			bool isValid;
			do
			{
				Console.WriteLine("Congratulations on your account Opening Champ!\nDo you want to proceed to Login ? Y or N\n");
				press = Console.ReadLine();

				if (press == "y" || press == "Y")
				{
					isValid = true;
					GoToLogin();
				}
				else if (press == "N" || press == "n")
				{
					isValid = true;
					Program.Controller();
				}
				else
				{
					isValid = false;
				}
			}while (isValid is false);

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
				cusAccountType = "savings";
				decimal accBal = 0;
				bool isValid ;

				Console.WriteLine("You need to deposit at least 1000 naira to open such an account");
				Console.Write("Please enter an amount greater or equal to 1000 naira: ");

				string enteredAmount = Console.ReadLine();
				do
				{
					
					if (enteredAmount == "1000" || int.Parse(enteredAmount) >= 1000)
					{
						isValid= true;
						decimal cleanAmount = decimal.Parse(enteredAmount);
						accBal += cleanAmount;
						Account account = new Account(cusFullname, cusAccountNo, cusAccountType, accBal);
						Console.WriteLine($"You have successfully added {cleanAmount} naira to your new account >> {cusAccountNo} ");
					}
					else
					{
						isValid = false;
						Console.WriteLine($"Invalid amount!. You need to enter an amount greater then 1000 naira. ");
						Console.WriteLine($"Processed Restarted !");
						AccountType();
					}
				} while (isValid == false);
			}
			else if (input == "2")
			{
				cusAccountType = "current";
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
			do
			{
				Console.Clear();
				Console.WriteLine("Enter your fullname to register \n(Both Should start with a capital Letter E.G John Kehinde)");
				cusFullname = Console.ReadLine().Trim();

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
