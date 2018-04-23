using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountServiceMoqTests
    {
        #region Fields

        private static Mock<IRepository> mockRepository;
        private static BankAccountService bankAccountService;

        #endregion Fields  

        #region Tests

        [Test]
        public void GetAll_SuccessfulExecution()
        {
            mockRepository = new Mock<IRepository>();
            mockRepository.Setup(repository => repository.GetAll()).Returns(GetBankAccounts());
            bankAccountService = new BankAccountService(mockRepository.Object);

            bankAccountService.GetAll();

            mockRepository.Verify(repositoty => repositoty.GetAll(), Times.Once);
        }

        [TestCase("Videneeva", "Anna", 100, GradingType.Gold)]
        [TestCase("Frolov", "Slava", 200, GradingType.Platinum)]
        [TestCase("Ageeva", "Alina", 300, GradingType.Base)]
        [TestCase("Stupen", "Maria", 400, GradingType.Gold)]
        [TestCase("Eroshencova", "Polina", 500, GradingType.Base)]
        [TestCase("Kutircina", "Elizaveta", 600, GradingType.Platinum)]
        public void Open_SuccessfulExecution(string ownerName, string ownerSurname, double amount, GradingType gradingType)
        {
            mockRepository = new Mock<IRepository>();
            bankAccountService = new BankAccountService(mockRepository.Object);

            bankAccountService.Open(ownerName, ownerSurname, amount, gradingType);

            mockRepository.Verify(
                repositoty => repositoty.Update(
                It.Is<Account>(account =>
                account.OwnerName == ownerName &&
                account.OwnerSurname == ownerSurname &&
                account.Amount == amount &&
                account.TypeGrading == (int)gradingType)),
                Times.Once);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Close_SuccessfulExecution(int id)
        {
            mockRepository = new Mock<IRepository>();
            mockRepository.Setup(repository => repository.GetAll()).Returns(GetBankAccounts());
            bankAccountService = new BankAccountService(mockRepository.Object);

            bankAccountService.Close(id);

            mockRepository.Verify(
                repository => repository.Delete(
                It.Is<Account>(account =>
                account.Id == id)),
                Times.Once);
        }

        [TestCase(0, 10)]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(3, 10)]
        [TestCase(4, 10)]
        [TestCase(5, 10)]
        public void Refill_SuccessfulExecution(int id, double amount)
        {
            mockRepository = new Mock<IRepository>();
            mockRepository.Setup(repository => repository.GetAll()).Returns(GetBankAccounts());
            bankAccountService = new BankAccountService(mockRepository.Object);

            bankAccountService.Refill(id, amount);

            mockRepository.Verify(
                repository => repository.Update(
                It.Is<Account>(account =>
                account.Id == id)),
                Times.Once);
        }

        [TestCase(0, 10)]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(3, 10)]
        [TestCase(4, 10)]
        [TestCase(5, 10)]
        public void Withdrawal_SuccessfulExecution(int id, double amount)
        {
            mockRepository = new Mock<IRepository>();
            mockRepository.Setup(repository => repository.GetAll()).Returns(GetBankAccounts());
            bankAccountService = new BankAccountService(mockRepository.Object);

            bankAccountService.Withdrawal(id, amount);

            mockRepository.Verify(
                repository => repository.Update(
                It.Is<Account>(account =>
                account.Id == id)),
                Times.Once);
        }

        #endregion Tests

        #region Private methods

        private static IEnumerable<Account> GetBankAccounts()
        {
            yield return new Account()
            {
                Id = 0,
                OwnerName = "Videneeva",
                OwnerSurname = "Anna",
                Amount = 100,
                BonusPoints = 4,
                TypeGrading = (int)GradingType.Gold
            };

            yield return new Account()
            {
                Id = 1,
                OwnerName = "Frolov",
                OwnerSurname = "Slava",
                Amount = 200,
                BonusPoints = 8,
                TypeGrading = (int)GradingType.Platinum
            };
       
            yield return new Account()
            {
                Id = 2,
                OwnerName = "Ageeva",
                OwnerSurname = "Alina",
                Amount = 300,
                BonusPoints = 2,
                TypeGrading = (int)GradingType.Base
            };

            yield return new Account()
            {
                Id = 3,
                OwnerName = "Stupen",
                OwnerSurname = "Maria",
                Amount = 400,
                BonusPoints = 4,
                TypeGrading = (int)GradingType.Gold
            };

            yield return new Account()
            {
                Id = 4,
                OwnerName = "Eroshenkova",
                OwnerSurname = "Polina",
                Amount = 500,
                BonusPoints = 2,
                TypeGrading = (int)GradingType.Base
            };

            yield return new Account()
            {
                Id = 5,
                OwnerName = "Kutircina",
                OwnerSurname = "Elizaveta",
                Amount = 600,
                BonusPoints = 8,
                TypeGrading = (int)GradingType.Platinum
            };
        }

        #endregion Private methods
    }
}