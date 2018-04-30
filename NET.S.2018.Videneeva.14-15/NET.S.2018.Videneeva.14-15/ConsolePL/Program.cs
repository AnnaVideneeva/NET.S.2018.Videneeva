using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigureResolver();
        }

        public static void Main(string[] args)
        {
            IBankAccountService accountService = Resolver.Get<IBankAccountService>();

            accountService.Open("Videneeva", "Anna", 100, GradingType.Gold);
            accountService.Open("Frolov", "Slava", 200, GradingType.Platinum);
            accountService.Open("Ageeva", "Alina", 300, GradingType.Base);
            accountService.Open("Stupen", "Maria", 400, GradingType.Gold);
            accountService.Open("Eroshencova", "Polina", 500, GradingType.Base);
            accountService.Open("Kutircina", "Elizaveta", 600, GradingType.Platinum);

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Refill(account.Id, 100);
            }

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Withdrawal(account.Id, 10);
            }

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Close(account.Id);
            }
        }

        private static void Display(IBankAccountService accountService)
        {
            Console.WriteLine("*****************************************");

            foreach (var account in accountService.GetAll())
            {
                Console.WriteLine(account);
            }
        }
    }
}