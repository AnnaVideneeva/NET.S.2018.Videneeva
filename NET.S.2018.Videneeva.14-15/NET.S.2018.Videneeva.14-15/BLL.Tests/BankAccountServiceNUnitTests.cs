using NUnit.Framework;
using BLL.ServiceImplementation;
using System.Collections.Generic;
using BLL.Interface.Entities;
using System.Linq;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountServiceNUnitTests
    {
        #region Fields

        private BankAccountService bankAccountService;

        #endregion Fields

        #region Tests

        [Test]
        public void GetAll_SuccessfulExecution()
        {
            bankAccountService = new BankAccountService(GetBankAccounts());

            Assert.AreEqual(bankAccountService.GetAll(), GetBankAccounts());
        }

        [TestCase("Videneeva", "Anna", 100, GradingType.Gold, ExpectedResult = true)]
        [TestCase("Frolov", "Slava", 200, GradingType.Platinum, ExpectedResult = true)]
        [TestCase("Ageeva", "Alina", 300, GradingType.Base, ExpectedResult = true)]
        [TestCase("Stupen", "Maria", 400, GradingType.Gold, ExpectedResult = true)]
        [TestCase("Eroshencova", "Polina", 500, GradingType.Base, ExpectedResult = true)]
        [TestCase("Kutircina", "Elizaveta", 600, GradingType.Platinum, ExpectedResult = true)]
        public bool Open_SuccessfulExecution(string ownerName, string ownerSurname, double amount, GradingType gradingType)
        {
            bankAccountService = new BankAccountService(GetNewBankAccounts());

            bankAccountService.Open(ownerName, ownerSurname, amount, gradingType);

            return bankAccountService.GetAll().Last().OwnerName == ownerName
                && bankAccountService.GetAll().Last().OwnerSurname == ownerSurname
                && bankAccountService.GetAll().Last().Amount == amount
                && bankAccountService.GetAll().Last().TypeGrading == gradingType;
        }

        [TestCase(0, ExpectedResult = 5)]
        [TestCase(1, ExpectedResult = 5)]
        [TestCase(2, ExpectedResult = 5)]
        [TestCase(3, ExpectedResult = 5)]
        [TestCase(4, ExpectedResult = 5)]
        [TestCase(5, ExpectedResult = 5)]
        public int Close_SuccessfulExecution(int id)
        {
            bankAccountService = new BankAccountService(GetBankAccounts());

            bankAccountService.Close(id);

            return bankAccountService.GetAll().Count();
        }

        [TestCase(0, 10, ExpectedResult = 110)]
        [TestCase(1, 10, ExpectedResult = 210)]
        [TestCase(2, 10, ExpectedResult = 310)]
        [TestCase(3, 10, ExpectedResult = 410)]
        [TestCase(4, 10, ExpectedResult = 510)]
        [TestCase(5, 10, ExpectedResult = 610)]
        public double Refill_SuccessfulExecution(int id, double amount)
        {
            bankAccountService = new BankAccountService(GetBankAccounts());

            bankAccountService.Refill(id, amount);

            return bankAccountService.GetAll().ElementAt(id).Amount;
        }

        [TestCase(0, 10, ExpectedResult = 90)]
        [TestCase(1, 10, ExpectedResult = 190)]
        [TestCase(2, 10, ExpectedResult = 290)]
        [TestCase(3, 10, ExpectedResult = 390)]
        [TestCase(4, 10, ExpectedResult = 490)]
        [TestCase(5, 10, ExpectedResult = 590)]
        public double Withdrawal_SuccessfulExecution(int id, double amount)
        {
            bankAccountService = new BankAccountService(GetBankAccounts());

            bankAccountService.Withdrawal(id, amount);

            return bankAccountService.GetAll().ElementAt(id).Amount;
        }

        #endregion Tests

        #region Private methods

        private static IEnumerable<BankAccount> GetBankAccounts()
        {
            return new List<BankAccount>
            {
                new BankAccount(0, "Videneeva", "Anna", 100, 4, GradingType.Gold),
                new BankAccount(1, "Frolov", "Slava", 200, 8, GradingType.Platinum),
                new BankAccount(2, "Ageeva", "Alina", 300, 4, GradingType.Base),
                new BankAccount(3, "Stupen", "Maria", 400, 6, GradingType.Gold),
                new BankAccount(4, "Eroshencova", "Polina", 500, 4, GradingType.Base),
                new BankAccount(5,"Kutircina", "Elizaveta", 600, 8, GradingType.Platinum)
            };
        }

        private static IEnumerable<BankAccount> GetNewBankAccounts()
        {
            return new List<BankAccount>();
        }

        #endregion Private methods
    }
}