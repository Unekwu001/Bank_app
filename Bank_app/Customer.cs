using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Customer
	{
		public string fullname { set; get; }
		public string accountNo { set; get; }
		public string accountType { set; get; }
		public string email { set; get; }
		public string password { set; get;} 


		internal Customer(string Fullname,string AccountNo,string AccountType,string Email,string Password)
		{
	        fullname = Fullname;
			accountNo = AccountNo;
			accountType = AccountType;
			email = Email;
			password = Password;
		}
	}
}
