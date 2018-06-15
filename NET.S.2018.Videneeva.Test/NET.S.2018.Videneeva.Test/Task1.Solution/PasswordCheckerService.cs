using System;
using System.Collections.Generic;
using Task1.Solution.Interfaces;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        private readonly IRepository repository;

        public PasswordCheckerService(IRepository repository)
        {
            this.repository = repository;
        }

        public Tuple<bool, string> Create(string password, IEnumerable<IChecker> checkers)
        {
            Tuple<bool, string> flag = new Tuple<bool, string>(true, "Password is Ok. User was created");

            foreach (var checker in checkers)
            {
                flag = checker.VerifyPassword(password);

                if (!flag.Item1)
                {
                    return flag;
                }
            }

            repository.Create(password);
            return flag;
        }
    }
}
