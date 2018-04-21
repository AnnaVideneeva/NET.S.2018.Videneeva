using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Provides methods for working with the data store.
    /// </summary>
    public class AccountsStorage
    {
        #region Fields

        private IRepository repository;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public AccountsStorage()
        {
            this.Repository = new AccountsFileStorage();
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties

        #region Public methods for work with repository

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<Account>.</returns>
        public IEnumerable<Account> GetAll()
        {
            return this.Repository.GetAll();
        }

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        /// <param name="id">An object id.</param>
        /// <returns>An object with such <paramref name="id"/>.</returns>
        public Account Get(int id)
        {  
            return this.Repository.Get(id);
        }

        /// <summary>
        /// Adds new object to storage.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="account"/> is null.</exception>
        /// <param name="account">A new object.</param>
        public void Add(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.Repository.Add(account);
        }

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="account"/> is null.</exception>
        /// <param name="account">The data about the object.</param>
        public void Update(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.Repository.Add(account);
        }

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="account"/> is null.</exception>
        /// <param name="account">The data about the object.</param>
        public void Delete(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.Repository.Delete(account);
        }

        #endregion Public methods for work with repository
    }
}
