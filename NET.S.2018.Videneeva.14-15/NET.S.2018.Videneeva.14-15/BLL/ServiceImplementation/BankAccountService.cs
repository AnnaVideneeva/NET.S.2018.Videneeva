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
    public class BankAccountService : IBankAccountService
    {
        #region Fields

        private IGenerator generator;

        private IRepository repository;

        private List<BankAccount> listAccounts;

        #endregion Fields

        #region Constructor

        public BankAccountService(IGenerator generator, IRepository repository)
        {
            this.Generator = generator;
            this.Repository = repository;
            this.ListAccounts = repository.GetAll().ToListBankAccount();
        }

        public BankAccountService() : this(new Generator(), new AccountsFileStorage())
        {
        }

        #endregion Constructor

        #region Properties

        public IGenerator Generator
        {
            get => this.generator;

            private set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.generator = value;
            }
        }

        public IRepository Repository
        {
            get => this.repository;

            private set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.repository = value;
            }
        }

        public List<BankAccount> ListAccounts
        {
            get => this.listAccounts;

            private set
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
        /// Opens a new bank account.
        /// </summary>
        /// <param name="ownerName">Name of bank account holder.</param>
        /// <param name="ownerSurname">Surname of bank account holder.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="gradingType">Type of bank account graduation.</param>
        public void Open(string ownerName, string ownerSurname, double amount, GradingType gradingType)
        {
         
        }

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        /// <param name="id">The id of the bank account.</param>
        public void Close(int id)
        {

        }

        /// <summary>
        /// Refills a bank account with the account <paramref name="id"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        public void Refill(int id, decimal amount)
        {

        }

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the bank account with the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to withdrawal.</param>
        public void Withdrawal(int id, decimal amount)
        {

        }
        
        #endregion IBankAccountService implementation

    }
}