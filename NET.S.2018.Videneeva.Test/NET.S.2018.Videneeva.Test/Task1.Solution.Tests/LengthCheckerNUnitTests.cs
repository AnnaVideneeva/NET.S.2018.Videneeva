using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution.Interfaces;
using Task1.Solution.Services;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class LengthCheckerNUnitTests
    {
        [TestCase("qwert123", ExpectedResult = true)]
        [TestCase("qw", ExpectedResult = false)]
        [TestCase("1qwert123", ExpectedResult = true)]
        [TestCase("1qwert1234567890", ExpectedResult = false)]
        public bool LengthChecker_VerifyPassword_SuccessfulExecution(string str)
        {
            IChecker checker = new LengthChecker();
            return checker.VerifyPassword(str).Item1;
        }
    }
}
