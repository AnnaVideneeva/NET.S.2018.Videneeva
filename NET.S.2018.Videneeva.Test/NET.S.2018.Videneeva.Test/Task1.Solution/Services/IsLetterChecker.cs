using System;
using System.Linq;
using Task1.Solution.Interfaces;

namespace Task1.Solution.Services
{
    public class IsLetterChecker : IChecker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }       
    }
}
