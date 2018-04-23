using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private List<BankAccount> listAccounts;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new state of the object by <paramref name="repository"/> and <paramref name="generator"/>.
        /// </summary>
        /// <param name="repository">The storage for objects of BankAccount type.</param>
        /// <param name="generator">The generator id.</param>
        public BankAccountService(IRepository repository, IGenerator generator)
        {
            this.Repository = repository;
            this.ListAccounts = this.GetListBankAccounts();
            this.Generator = generator;
        }

        /// <summary>
        /// Initializes a new state of the object by <paramref name="listBankAccounts"/>.
        /// </summary>
        /// <param name="listBankAccounts">The sequence of objects of BankAccount type.</param>
        public BankAccountService(IEnumerable<BankAccount> listBankAccounts)
        {
            this.ListAccounts = listBankAccounts.ToList();
            this.Repository = new AccountsFileStorage(listBankAccounts.ToListAccount());
            this.Generator = new Generator(this.ListAccounts.Count);
        }

        /// <summary>
        /// Initializes a new state of the object by <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The storage for objects of BankAccount type.</param>
        public BankAccountService(IRepository repository)
        {
            this.Repository = repository;
            this.ListAccounts = this.GetListBankAccounts();
            this.Generator = new Generator(this.ListAccounts.Count);
        }

        /// <summary>
        /// Initializes a new state of the object.
        /// </summary>
        public BankAccountService() : this(new AccountsFileStorage())
        {
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
        /// Gets and sets a sequence of objects of BankAccount type.
        /// </summary>
        private List<BankAccount> ListAccounts
        {
            get => this.listAccounts;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.listAccounts = value;
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
            return this.ListAccounts;
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

            this.ListAccounts.Add(bankAccount);
            this.Repository.Add(bankAccount.ToAccount());

            this.Refill(id, amount);
        }

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        public void Close(int id)
        {
            BankAccount bankAccount = this.ListAccounts.Find(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.Repository.Delete(bankAccount.ToAccount());
            this.ListAccounts.Remove(bankAccount);
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

            BankAccount bankAccount = this.ListAccounts.Find(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            int index = this.ListAccounts.IndexOf(bankAccount);
            this.ListAccounts.Remove(bankAccount);

            IBonusCounter bonusCounter = new BonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.BonusPoints = bonusCounter.Increase(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());

            this.ListAccounts.Insert(index, bankAccount);
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

            BankAccount bankAccount = this.ListAccounts.Find(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            int index = this.ListAccounts.IndexOf(bankAccount);
            this.ListAccounts.Remove(bankAccount);

            IBonusCounter bonusCounter = new BonusCounter(bankAccount.TypeGrading);

            bankAccount.Amount = bankAccount.Amount - amount;
            bankAccount.BonusPoints = bonusCounter.Reduction(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());

            this.ListAccounts.Insert(index, bankAccount);
        }

        #endregion IBankAccountService implementation

        #region Private methods

        private List<BankAccount> GetListBankAccounts()
        {
            List<BankAccount> listBankAccounts = this.Repository
                .GetAll()
                .ToListBankAccount();

            if (ReferenceEquals(null, listBankAccounts))
            {
                return new List<BankAccount>();
            }

            return listBankAccounts;
        }

        #endregion Private methods
    }
}