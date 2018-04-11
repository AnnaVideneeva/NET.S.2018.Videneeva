using NUnit.Framework;

namespace BankAccounts.Tests
{
    [TestFixture]
    public class AccountNUnitTests
    {
        #region Equals tests

        [TestCase(ExpectedResult = true)]
        public bool Equals_AccountAndAccount_SuccessfulExecution()
        {
            Account firstAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            Account secondAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            return firstAccount.Equals(secondAccount);
        }

        [TestCase(ExpectedResult = true)]
        public bool Equals_AccountAndObject_SuccessfulExecution()
        {
            Account firstAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            object secondAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            return firstAccount.Equals(secondAccount);
        }

        [TestCase(ExpectedResult = false)]
        public bool Equals_AccountAndAccount_UnsuccessfulExecution()
        {
            Account firstAccount = new Account(131, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            Account secondAccount = new Account(132, "Байцов", "Александр", 1000, 200, GradingType.Gold);
            return firstAccount.Equals(secondAccount);
        }

        #endregion Equals tests
    }
}