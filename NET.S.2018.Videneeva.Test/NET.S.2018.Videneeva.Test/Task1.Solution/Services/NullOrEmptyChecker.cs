using System;
using Task1.Solution.Interfaces;

namespace Task1.Solution.Services
{
    public class NullOrEmptyChecker : IChecker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentException($"{password} is null arg");
            }
               
            if (password == string.Empty)
            {
                return Tuple.Create(false, $"{password} is empty ");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}