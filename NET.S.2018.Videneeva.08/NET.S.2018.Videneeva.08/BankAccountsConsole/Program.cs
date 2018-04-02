using BankAccounts;
using System;
using System.Linq;

namespace BankAccountsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Account firstAccount = new Account(123, "Кутыркина", "Елизавета", GradingType.Base);
            Account secondAccount = new Account(125, "Калесникова", "Вероника", 100, 10, GradingType.Gold);
            Account thirdAccount = new Account(127, "Осадчий", "Юрий", GradingType.Base);
            Account fourthAccount = new Account(129, "Касперович", "Алина", 2050, 50, GradingType.Platinum);
            Account fifthAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);

            AccountsService firstAccountsService = new AccountsService();
            firstAccountsService.AddNewAccount(firstAccount);
            firstAccountsService.AddNewAccount(secondAccount);

            firstAccountsService.CloseAccount(secondAccount);

            firstAccountsService.AddNewAccount(secondAccount);
            firstAccountsService.AddNewAccount(thirdAccount);

            firstAccountsService.CloseAccount(thirdAccount);

            firstAccountsService.AddNewAccount(thirdAccount);
            firstAccountsService.AddNewAccount(fourthAccount);
            firstAccountsService.AddNewAccount(fifthAccount);

            ConsoleWrite(firstAccountsService);

            firstAccount.AccountReplenishment(200);
            secondAccount.WithdrawalsFromAccount(10);

            try
            {
                thirdAccount.WithdrawalsFromAccount(200);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            fourthAccount.WithdrawalsFromAccount(200);
            fifthAccount.AccountReplenishment(200);

            firstAccountsService.WriteDataToFile();

            AccountsService secondAccountsService = new AccountsService();
            secondAccountsService.ReadDataFromFile();

            ConsoleWrite(secondAccountsService);

        }

        public static void ConsoleWrite(AccountsService accountsService)
        {
            for (int i = 0; i < accountsService.Count; i++)
            {
                Console.WriteLine(accountsService.ListAccounts.ElementAt(i).ToString());
                Console.WriteLine();
            }
        }
    }
}
