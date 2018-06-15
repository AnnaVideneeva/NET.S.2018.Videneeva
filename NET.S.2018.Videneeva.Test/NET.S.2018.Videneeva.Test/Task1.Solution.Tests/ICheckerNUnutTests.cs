using System;
using NUnit.Framework;
using Task1.Solution.Interfaces;
using Task1.Solution.Services;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class ICheckerNUnutTests
    {
        [TestCase("qwert123", ExpectedResult = true)]
        [TestCase("sdf", ExpectedResult = true)]
        [TestCase("1123", ExpectedResult = false)]
        public bool IsLetterChecker_VerifyPassword_SuccessfulExecution(string str)
        {
            IChecker checker = new IsLetterChecker();
            return checker.VerifyPassword(str).Item1;
        }
    }
}
