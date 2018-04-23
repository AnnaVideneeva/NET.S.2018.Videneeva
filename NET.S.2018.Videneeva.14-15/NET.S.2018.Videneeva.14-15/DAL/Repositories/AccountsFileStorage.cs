using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Provides methods for working with the data store as a file.
    /// </summary>
    public class AccountsFileStorage : IRepository
    {
        #region Static constructor

        /// <summary>
        /// The static cinstructor to initialize the Path.
        /// </summary>
        static AccountsFileStorage()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + "AccountListStorage.txt";
        }

        #endregion Static constructor

        #region Constructors

        /// <summary>
        /// Initializes a new state of the object by <paramref name="listAccounts"/>.
        /// </summary>
        /// <param name="listAccounts">The sequence of objects of BankAccount type.</param>
        public AccountsFileStorage(IEnumerable<Account> listAccounts)
        {
            this.WriteDataToFile(listAccounts);
        }

        /// <summary>
        /// Initializes a new state.
        /// </summary>
        public AccountsFileStorage()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The path to the file with the collection of accounts.
        /// </summary>
        public static string Path { get; private set; }

        #endregion Properties

        #region IRepository<Account> implementation

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<Account>.</returns>
        public IEnumerable<Account> GetAll()
        {
            return this.ReadDataFromFile();
        }

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        /// <param name="id">An object id.</param>
        /// <exception cref="KeyNotFoundException">Throw when an object with such <paramref name="id"/> is not found.</exception>
        /// <returns>An object with such <paramref name="id"/>.</returns>
        public Account Get(int id)
        {
            Account account = this.ReadDataFromFile()
                .ToList()
                .Find(element => element.Id == id);

            if (ReferenceEquals(null, account))
            {
                throw new KeyNotFoundException("Account with such id is not found.");
            }

            return account;
        }

        /// <summary>
        /// Adds new object to file.
        /// </summary>
        /// <exception cref="DuplicateWaitObjectException">Throw when <paramref name="account"/> already exists.</exception>
        /// <param name="account">A new object.</param>
        public void Add(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            if (listAccounts.Exists(element => element.Id == account.Id))
            {
                throw new DuplicateWaitObjectException("This account already exists.");
            }

            listAccounts.Add(account);
            this.AppendDataToFile(account);
        }

        /// <summary>
        /// Updates the data about the object.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Throw when id of <paramref name="account"/> is not found.</exception>
        /// <param name="account">The data about the object.</param>
        public void Update(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            Account findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (ReferenceEquals(null, findingAccount))
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            int index = listAccounts.IndexOf(findingAccount);

            listAccounts.Remove(findingAccount);
            listAccounts.Insert(index, account);

            this.WriteDataToFile(listAccounts);
        }

        /// <summary>
        /// Deletes the data about the object.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Throw when id of <paramref name="account"/> is not found.</exception>
        /// <param name="account">The data about the object.</param>
        public void Delete(Account account)
        {
            List<Account> listAccounts = this.ReadDataFromFile().ToList();

            Account findingAccount = listAccounts.Find(element => element.Id == account.Id);

            if (ReferenceEquals(null, findingAccount))
            {
                throw new KeyNotFoundException("This account is not found.");
            }

            listAccounts.Remove(findingAccount);

            this.WriteDataToFile(listAccounts);
        }

        #endregion IRepository<Account> implementation

        #region Private method for working with file

        private IEnumerable<Account> ReadDataFromFile()
        {
            var listAccounts = new List<Account>();

            FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            while (reader.PeekChar() != -1)
            {
                Account account = new Account
                {
                    Id = reader.ReadInt32(),
                    OwnerName = reader.ReadString(),
                    OwnerSurname = reader.ReadString(),
                    Amount = reader.ReadDouble(),
                    BonusPoints = reader.ReadInt32(),
                    TypeGrading = reader.ReadInt32()
                };
                listAccounts.Add(account);
            }

            reader.Close();
            file.Close();

            return listAccounts;
        }

        private void WriteDataToFile(IEnumerable<Account> listAccounts)
        {
            if (ReferenceEquals(null, listAccounts))
            {
                throw new ArgumentNullException(nameof(listAccounts));
            }

            FileStream file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            foreach (var account in listAccounts)
            {
                writer.Write(account.Id);
                writer.Write(account.OwnerName);
                writer.Write(account.OwnerSurname);
                writer.Write(account.Amount);
                writer.Write(account.BonusPoints);
                writer.Write(account.TypeGrading);
            }

            writer.Close();
            file.Close();
        }

        private void AppendDataToFile(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException(nameof(account));
            }

            FileStream file = new FileStream(Path, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(account.Id);
            writer.Write(account.OwnerName);
            writer.Write(account.OwnerSurname);
            writer.Write(account.Amount);
            writer.Write(account.BonusPoints);
            writer.Write(account.TypeGrading);

            writer.Close();
            file.Close();
        }

        #endregion Private method for working with file
    }
}