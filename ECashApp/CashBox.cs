using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECashApp
{
	public class CashBox
	{
		public List<Account> Accounts { get; private set; }

		public CashBox()
		{
			Accounts = new List<Account>();
		}
		public void AddAccount(Account account)
		{
			Accounts.Add(account);
		}

		public void ShowAllAccounts()
		{
			foreach (var acc in Accounts)
			{
				Console.WriteLine($"{acc.Number}  {acc.Balance} {acc.Currency}  {acc.Description}  {acc.Status}");
			}
		}
		public Account GetAccountByNumber(int number)
		{
			foreach (var acc in Accounts)
			{
				if (acc.Number == number)
					return acc;
			}

			return null;
		}
	}
}
