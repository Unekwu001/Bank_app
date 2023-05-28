using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Program
	{
		//fields
		public readonly string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
		public readonly string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
		public readonly string namePattern = @"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$";
		public static string choice;



		//Entry point
		static void Main(string[] args)
		{
			
			Controller();
			
		}

      //------------------------------------------------------------------------------------------------
		
		//The controller
		public static void Controller()
		{
			
			do
			{
				Console.Clear();
				Console.WriteLine("Welcome to Shazam Bank\n\n\n>Press 1 To Register\n\n>Press 2 To login\n\n ");
				choice = Console.ReadLine();
				
				if (choice == "1")
				{
					var customa = new RegisterCustomer();
					customa.Registration();
					
				}
				if (choice == "2")
				{
				
					Console.Clear();
					var mylogin = new Login();
					mylogin.ApproveLogin();
				}

			}
			while (!int.TryParse(choice, out _) || int.Parse(choice) != 1 || int.Parse(choice) != 2);

			 
			
			
			
		}
	}
}
