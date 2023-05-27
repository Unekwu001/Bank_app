using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Login: RegisterCustomer
	{
		public string myemail { get; set; }
		public string mypassword { get; set; }

		public Login()
		{
			myemail = myemail;
			mypassword = mypassword;
			
			
		}

		public void ApproveLogin() // login with email and password
		{
			do {
				Console.Clear();
				Console.WriteLine("Login with the correct email here.");
				myemail = Console.ReadLine();
			} while (!Regex.IsMatch(myemail, emailPattern));
			do
			{
				Console.Clear();
				Console.WriteLine("Enter your Login password");
				mypassword = Console.ReadLine();
			} while (!Regex.IsMatch(mypassword, passwordPattern));

			Customer customer = Program.customers.Find(c => c.email == myemail && c.password == mypassword);
			if (customer is null)
			{
				Console.Clear();
				Console.WriteLine("Invalid username or password. Please try again.");
				Console.WriteLine("Press A");

			}
			else
			{
				loggedInCustomer = customer;
				Console.WriteLine("Login successful.");

			}


		}



	}
}
