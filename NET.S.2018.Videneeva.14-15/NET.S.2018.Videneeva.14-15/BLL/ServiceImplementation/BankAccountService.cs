using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides methods for working with a bank accounts list.
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        #region Fields

        private IGenerator generator;
        private IRepository repository;
        private IBonusCounter bonusCounter;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new state of the object by <paramref name="bonusCounter"/>, <paramref name="generator"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The storage for objects of BankAccount type.</param>
        /// <param name="generator">The generator id.</param>
        /// <param name="bonusCounter">The bonus counter.</param>
        public BankAccountService(IRepository repository, IGenerator generator, IBonusCounter bonusCounter)
        {
            this.Repository = repository;
            this.Generator = generator;
            this.BonusCounter = bonusCounter;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets and sets id geterator. 
        /// </summary>
        private IGenerator Generator
        {
            get => this.generator;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.generator = value;
            }
        }

        /// <summary>
        /// Gets and sets objects of BankAccount type.
        /// </summary>
        private IRepository Repository
        {
            get => this.repository;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.repository = value;
            }
        }

        /// <summary>
        /// The bonus counter.
        /// </summary>
        private IBonusCounter BonusCounter
        {
            get => this.bonusCounter;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.bonusCounter = value;
            }
        }

        #endregion Properties

        #region IBankAccountService implementation

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<BankAccount>.</returns>
        public IEnumerable<BankAccount> GetAll()
        {
            return this.Repository.GetAll().Select(item => item.ToBankAccount());
        }

        /// <summary>
        /// Opens a new bank account.
        /// </summary>
        /// <param name="ownerName">Name of bank account holder.</param>
        /// <param name="ownerSurname">Surname of bank account holder.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="gradingType">Type of bank account graduation.</param>
        public void Open(string ownerName, string ownerSurname, double amount, GradingType gradingType)
        {
            int id = this.Generator.GenerateId();

            BankAccount bankAccount = new BankAccount(id, ownerName, ownerSurname, 0, 0, gradingType);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.BonusPoints = this.BonusCounter.Increase(bankAccount.BonusPoints);

            this.Repository.Add(bankAccount.ToAccount());
        }

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        public void Close(int id)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.Repository.Delete(bankAccount.ToAccount());
        }

        /// <summary>
        /// Refills a bank account with the account <paramref name="id"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        public void Refill(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.BonusPoints = this.BonusCounter.Increase(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());
        }

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the bank account with the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to withdrawal.</param>
        public void Withdrawal(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount = bankAccount.Amount - amount;
            bankAccount.BonusPoints = this.BonusCounter.Reduction(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());
        }

        #endregion IBankAccountService implementation
    }
}