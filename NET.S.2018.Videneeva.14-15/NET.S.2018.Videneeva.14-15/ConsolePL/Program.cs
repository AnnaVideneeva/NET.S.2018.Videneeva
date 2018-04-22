using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigureResolver();
        }

        static void Main(string[] args)
        {
            IBankAccountService accountService = resolver.Get<IBankAccountService>();
            IGenerator creator = resolver.Get<IGenerator>();

            accountService.Open("Videneeva", "Anna", 100, GradingType.Gold);
            accountService.Open("Frolov", "Slava", 200, GradingType.Platinum);
            accountService.Open("Ageeva", "Alina", 300, GradingType.Base);
            accountService.Open("Stupen", "Maria", 400, GradingType.Gold);
            accountService.Open("Eroshencova", "Polina", 500, GradingType.Base);
            accountService.Open("Kutircina", "Elizaveta", 600, GradingType.Platinum);

            Display(accountService);

            accountService.Refill(0, 100);
            accountService.Refill(1, 100);
            accountService.Refill(2, 100);
            accountService.Refill(3, 100);
            accountService.Refill(4, 100);
            accountService.Refill(5, 100);

            Display(accountService);

            accountService.Withdrawal(0, 10);
            accountService.Withdrawal(1, 10);
            accountService.Withdrawal(2, 10);
            accountService.Withdrawal(3, 10);
            accountService.Withdrawal(4, 10);
            accountService.Withdrawal(5, 10);

            Display(accountService);

            accountService.Close(0);
            accountService.Close(1);
            accountService.Close(2);

            Display(accountService);
        }

        public static void Display(IBankAccountService accountService)
        {
            Console.WriteLine("*****************************************");

            foreach (var account in accountService.GetAll())
            {
                Console.WriteLine(account);
            }
        }
    }
}