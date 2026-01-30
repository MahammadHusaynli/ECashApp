using System;	

namespace ECashApp
{
	public class Account
	{
		public int Number { get; private set; }
		public Currency Currency { get; private set; }
		public decimal Balance { get; private set; }
		public string Description { get; private set; }
		public AccountStatus Status { get; private set; }

		public Account(int number, Currency currency, decimal balance, string description)
		{
			Number = number;
			Currency = currency;
			Balance = balance;
			Description = description;
			Status = AccountStatus.Active;
		}

		public void Deposit(decimal amount)
		{
			if (amount <= 0) return;
			Balance += amount;
		}

		public bool Withdraw(decimal amount)
		{
			if (amount <= 0)
			{
				return false;
			}
			if (amount > Balance)
			{
				return false;
			}

			Balance -= amount;
			return true;
		}
		public void ToggleStatus()
		{
			if (Status == AccountStatus.Active)
			{
				Status = AccountStatus.Deactive;
			}
			else
			{
				Status = AccountStatus.Active;
			}
		}
	}
}
