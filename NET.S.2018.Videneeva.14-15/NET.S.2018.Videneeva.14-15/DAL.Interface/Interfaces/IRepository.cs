using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Contains methods for working with data from account.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<Account>.</returns>
        IEnumerable<Account> GetAll();

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        /// <param name="id">An object id.</param>
        /// <returns>An object with such <paramref name="id"/>.</returns>
        Account Get(int id);

        /// <summary>
        /// Adds new object to storage.
        /// </summary>
        /// <param name="account">A new object.</param>
        void Add(Account account);

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        /// <param name="account">The data about the object.</param>
        void Update(Account account);

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        /// <param name="account">The data about the object.</param>
        void Delete(Account account);
    }
}