using System;
using System.Linq;
using Task1.Solution.Interfaces;

namespace Task1.Solution.Services
{
    public class IsNumberChecker : IChecker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
            {
                return Tuple.Create(false, $"{password} hasn't digits");
            }      

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
