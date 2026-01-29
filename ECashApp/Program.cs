using ECashApp;
using System;

namespace ECashApp
{
	internal class Program
	{
		static CashBox cashBox = null;
		static Random rnd = new Random();

		static void Main(string[] args)
		{
			int choice;

			do
			{
				Console.Clear();
				Console.WriteLine("1. Create E-CashBox");
				Console.WriteLine("2. Create Account");
				Console.WriteLine("3. Show All Accounts");
				Console.WriteLine("4. Account Operations");
				Console.WriteLine("5. Exit");
				Console.Write("Select: ");

				choice = ReadInt("Select: ");

				switch (choice)
				{
					case 1:
						CreateCashBox();
						break;
					case 2:
						CreateAccount();
						break;
					case 3:
						ShowAccounts();
						break;
					case 4:
						AccountMenu();
						break;
				}

			} while (choice != 5);
		}

		static void CreateCashBox()
		{
			if (cashBox != null)
			{
				Console.WriteLine("E-CashBox already exists");
				Console.ReadKey();
				return;
			}

			cashBox = new CashBox();
			Console.WriteLine("E-CashBox created");
			Console.ReadKey();
		}

		static void CreateAccount()
		{
			if (cashBox == null)
			{
				Console.WriteLine("Create E-CashBox first");
				Console.ReadKey();
				return;
			}

			char answer;

			do
			{

				Console.Write("Description: ");
				string desc = Console.ReadLine();

				Console.WriteLine("Select Currency: 1-AZN  2-USD");
				int curChoice = ReadInt("Choice: ");
				Currency currency = curChoice == 1 ? Currency.AZN : Currency.USD;

				decimal balance = ReadDecimal("Initial balance: ");

				int number = rnd.Next(10000000, 99999999);

				Account account = new Account(number, currency, balance, desc);
				cashBox.AddAccount(account);

				Console.WriteLine("Account created: " + number);

				Console.Write("Do you have another account? (B/N): ");
				string input = Console.ReadLine();
				answer = string.IsNullOrWhiteSpace(input) ? 'n' : input.ToLower()[0];

			} while (answer == 'b');

			Console.ReadKey();
		}

		static void ShowAccounts()
		{
			if (cashBox == null)
			{
				Console.WriteLine("No E-CashBox");
				Console.ReadKey();
				return;
			}

			cashBox.ShowAllAccounts();
			Console.ReadKey();
		}

		static void AccountMenu()
		{
			if (cashBox == null)
			{
				Console.WriteLine("No E-CashBox");
				Console.ReadKey();
				return;
			}

			int number = ReadInt("Account number: ");

			Account acc = cashBox.GetAccountByNumber(number);

			if (acc == null)
			{
				Console.WriteLine("Not found");
				Console.ReadKey();
				return;
			}

			char choice = 'd';

			do
			{
				Console.WriteLine("a) Deposit");
				Console.WriteLine("b) Withdraw");
				Console.WriteLine("c) Change Status");
				Console.WriteLine("d) Back");
				Console.Write("Select: ");

				string input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("Wrong choice");
					Console.ReadKey();
					continue;
				}

				choice = input.ToLower()[0];

				if (choice != 'a' && choice != 'b' && choice != 'c' && choice != 'd')
				{
					Console.WriteLine("Wrong choice");
					Console.ReadKey();
					continue;
				}

				if (choice == 'a')
				{
					if (acc.Status == AccountStatus.Deactive)
					{
						Console.WriteLine("Account is deactive");
					}
					else
					{
						decimal amount = ReadDecimal("Amount: ");
						acc.Deposit(amount);
					}
				}

				else if (choice == 'b')
				{
					if (acc.Status == AccountStatus.Deactive)
					{
						Console.WriteLine("Account is deactive");
					}
					else
					{
						decimal amount = ReadDecimal("Amount: ");
						bool ok = acc.Withdraw(amount);

						if (!ok)
							Console.WriteLine("Insufficient balance");
					}
				}

				else if (choice == 'c')
				{
					acc.ToggleStatus();
				}

				Console.ReadKey();

			} while (choice != 'd');
		}

		static int ReadInt(string message)
		{
			int value;
			while (true)
			{
				Console.Write(message);
				string input = Console.ReadLine();

				if (int.TryParse(input, out value))
					return value;

				Console.WriteLine("Please enter a valid number.");
			}
		}

		static decimal ReadDecimal(string message)
		{
			decimal value;
			while (true)
			{
				Console.Write(message);
				string input = Console.ReadLine();

				if (decimal.TryParse(input, out value))
					return value;

				Console.WriteLine("Please enter a valid amount.");
			}
		}
	}
}
