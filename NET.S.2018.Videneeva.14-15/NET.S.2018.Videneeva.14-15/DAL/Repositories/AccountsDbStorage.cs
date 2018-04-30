using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    /// <summary>
    /// Provides methods for working with the database.
    /// </summary>
    public class AccountsDbStorage : IRepository
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private BankContext context;

        /// <summary>
        /// Initialize new instance.
        /// </summary>
        public AccountsDbStorage()
        {
            this.context = new BankContext();
        }

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<Account>.</returns>
        public IEnumerable<Account> GetAll()
        {
            return context.BankAccounts.ToArray().Select(item => item.ToAccount());
        }

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        /// <param name="id">An object id.</param>
        /// <returns>An object with such <paramref name="id"/>.</returns>
        public Account Get(int id)
        {
            return context.BankAccounts.FirstOrDefault(item => item.Id == id).ToAccount();
        }

        /// <summary>
        /// Adds new object to storage.
        /// </summary>
        /// <param name="account">A new object.</param>
        public void Add(Account account)
        {
            context.BankAccounts.Add(account.ToBankAccount());
            context.SaveChanges();
        }

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        /// <param name="account">The data about the object.</param>
        public void Update(Account account)
        {
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).OwnerName = account.OwnerName;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).OwnerSurname = account.OwnerSurname;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).Amount = Convert.ToDecimal(account.Amount);
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).BonusPoints = account.BonusPoints;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).TypeGrading = account.TypeGrading;
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        /// <param name="account">The data about the object.</param>
        public void Delete(Account account)
        {
            context.BankAccounts.Remove(account.ToBankAccount());
            context.SaveChanges();
        }
    }
}
