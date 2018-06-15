using NUnit.Framework;
using Task1.Solution.Interfaces;
using Task1.Solution.Services;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class IsNumberCheckerNUnitTests
    {
        [TestCase("qwert123", ExpectedResult = true)]
        [TestCase("qw", ExpectedResult = false)]
        [TestCase("1qwert123", ExpectedResult = true)]
        public bool IsNumberChecker_VerifyPassword_SuccessfulExecution(string str)
        {
            IChecker checker = new IsNumberChecker();
            return checker.VerifyPassword(str).Item1;
        }
    }
}
