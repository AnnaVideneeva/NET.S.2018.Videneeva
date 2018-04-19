using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class AccountsStorage : IRepository<Account>
    {
        #region Fields

        private List<Account> accounts;

        #endregion Fields

        #region Constructors

        public AccountsStorage()
        {
            this.Accounts = new List<Account>();
        }

        public AccountsStorage(IEnumerable<Account> collection)
        {
            this.Accounts = collection.ToList();
        }

        #endregion Constructors

        #region Properties

        public List<Account> Accounts
        {
            get => this.accounts;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.accounts = value;
            }
        }

        #endregion Properties

        #region IRepository<Account> implementation

        public IEnumerable<Account> GetAll()
        {
            return this.Accounts;
        }

        public Account Get(int number)
        {
            Account account = Accounts.Find(element => element.Number == number);

            if (ReferenceEquals(null, account))
            {
                throw new KeyNotFoundException("Account with such number not found.");
            }

            return account;
        }

        public void Add(Account item)
        {
            if (ReferenceEquals(null, item))
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Accounts.Exists(element => element.Number == item.Number))
            {
                throw new DuplicateWaitObjectException("This account already exists.");
            }

            Accounts.Add(item);
            AccountsFileStorage.AppendDataToFile(item);
        }

        public void Update(Account item)
        {
            if (ReferenceEquals(null, item))
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!Accounts.Exists(element => element.Number == item.Number))
            {
                throw new KeyNotFoundException("This account not found.");
            }

            this.Accounts.Remove(this.Accounts.Find(element => element.Number == item.Number));
            this.Accounts.Add(item);
            AccountsFileStorage.WriteDataToFile(this.Accounts);
        }

        public void Delete(Account item)
        {
            if (ReferenceEquals(null, item))
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!Accounts.Exists(element => element.Number == item.Number))
            {
                throw new KeyNotFoundException("This account not found.");
            }

            this.Accounts.Remove(this.Accounts.Find(element => element.Number == item.Number));
            AccountsFileStorage.WriteDataToFile(this.Accounts);
        }

        #endregion IRepository<Account> implementation
    }
}
