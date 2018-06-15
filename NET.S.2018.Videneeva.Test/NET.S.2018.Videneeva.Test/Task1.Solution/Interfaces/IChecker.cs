using System;

namespace Task1.Solution.Interfaces
{
    public interface IChecker
    {
        Tuple<bool, string> VerifyPassword(string password);
    }
}
