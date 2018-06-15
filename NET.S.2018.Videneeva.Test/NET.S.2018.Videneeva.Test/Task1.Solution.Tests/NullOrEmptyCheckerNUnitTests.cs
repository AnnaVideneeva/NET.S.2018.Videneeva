using NUnit.Framework;
using Task1.Solution.Interfaces;
using Task1.Solution.Services;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class NullOrEmptyCheckerNUnitTests
    {
        [TestCase("qwert123", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        public bool NullOrEmptyChecker_VerifyPassword_SuccessfulExecution(string str)
        {
            IChecker checker = new NullOrEmptyChecker();
            return checker.VerifyPassword(str).Item1;
        }
    }
}
