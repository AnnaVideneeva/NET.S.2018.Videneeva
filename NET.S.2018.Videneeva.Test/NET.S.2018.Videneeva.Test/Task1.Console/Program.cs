using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Solution;
using Task1.Solution.Interfaces;
using Task1.Solution.Services;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new SqlRepository();
            PasswordCheckerService service = new PasswordCheckerService(repository);

            string password = "qwerty1234";
            List<IChecker> checkers = new List<IChecker>
            {
                new NullOrEmptyChecker(),
                new IsLetterChecker(),
                new IsNumberChecker(),
                new LengthChecker()
            };

            System.Console.WriteLine(service.Create(password, checkers).Item2);
            System.Console.ReadKey();
        }
    }
}
