using ORM.Entities;
using System.Data.Entity;

namespace ORM.Context
{
    /// <summary>
    /// The class context for interacting with the database.
    /// </summary>
    public class BankContext : DbContext
    {
        /// <summary>
        /// Initialize new context.
        /// </summary>
        public BankContext()
            : base("Bank")
        {
        }

        /// <summary>
        /// Get and set bank accounts from the database.
        /// </summary>
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
