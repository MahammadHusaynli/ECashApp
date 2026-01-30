using System;
using System.Collections.Generic;

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

		public List<Account> GetAllAccounts()
		{
			return Accounts;
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
