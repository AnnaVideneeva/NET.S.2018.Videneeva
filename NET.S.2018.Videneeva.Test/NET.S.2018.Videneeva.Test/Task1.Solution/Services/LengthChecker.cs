using System;
using Task1.Solution.Interfaces;

namespace Task1.Solution.Services
{
    public class LengthChecker : IChecker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if length more than 7 chars 
            if (password.Length <= 7)
            {
                return Tuple.Create(false, $"{password} length too short");
            }
                
            // check if length more than 10 chars for admins
            if (password.Length >= 15)
            {
                return Tuple.Create(false, $"{password} length too long");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
