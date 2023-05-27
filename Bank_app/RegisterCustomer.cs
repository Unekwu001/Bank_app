using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
		string cusFullname;
		string cusEmail;
		string cusPassword;
		string cusAccountNo;
		string cusAccountType;
		public readonly string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
		public readonly string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
		public readonly string namePattern = @"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$";

		internal void Registration() //Registration method 
		{
			Console.Clear();
			Console.WriteLine("Register to Shazam Bank\n");
			Console.WriteLine("What type of account do you want open ?\n\n");
			AccountType();
			Fullname();
			Email();
			Password();
			GenerateAccountNo();
			AddCustomer();
			var mylogin = new Login();
			mylogin.ApproveLogin();
		}

		//Printing of the all registered Customers
		internal void ShowMyRegistration()
		{
			foreach (var customer in customers)
			{
				Console.WriteLine($"Name: {customer.fullname}");
				Console.WriteLine($"Account Type: {customer.accountType}");
				Console.WriteLine($"Account Number: {customer.accountNo}");
				Console.WriteLine($"Email: {customer.email}");
				Console.WriteLine($"Password: **********");
				Console.WriteLine();
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------


		

		
		//-----------------------------------------------------------------------------------------------------------
		


		

		public void AccountType()
		{
			
			Console.WriteLine(">  Press 1 to open a savings account\n>  Press 2 to open a current account  ");
			cusAccountType = Console.ReadLine();

			string savings = "SAVINGS";
			string current = "CURRENT";

			if (cusAccountType == "1")
			{
				cusAccountType = savings;
			}
			else if (cusAccountType == "2")
			{
				cusAccountType = current;
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

		public void AddCustomer()
		{
			Customer existingCustomer = Program.customers.Find(c => c.email == cusEmail && c.password == cusPassword);
			if (existingCustomer != null)
			{
				Console.WriteLine("Username already exists. Please try again.");
				Registration();
			}
			else
			{
				var customer = new Customer(cusFullname, cusAccountType, cusAccountNo, cusEmail, cusPassword);
				customers.Add(customer);
				loggedInCustomer = customer;
				Console.WriteLine("Customer registered successfully!");
			}
		}
		
	}
}
