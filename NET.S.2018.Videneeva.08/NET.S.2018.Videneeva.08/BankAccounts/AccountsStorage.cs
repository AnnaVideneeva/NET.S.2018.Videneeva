using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankAccounts
{
    /// <summary>
    /// Provides methods for working with the data store.
    /// </summary>
    public static class AccountsStorage
    {
        #region Static constructor

        /// <summary>
        /// The static cinstructor to initialize the Path.
        /// </summary>
        static AccountsStorage()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + "AccountListStorage.txt";
        }

        #endregion Static constructor

        #region Properties

        /// <summary>
        /// The path to the file with the collection of accounts.
        /// </summary>
        public static string Path { get; private set; }

        #endregion Properties

        #region Method for working with file

        /// <summary>
        /// Reads account data from a file and creates a collection.
        /// </summary>
        /// <returns>The collection of accounts.</returns>
        public static List<Account> ReadDataFromFile()
        {
            var listAccounts = new List<Account>();

            FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            if (reader.PeekChar() == -1)
            {
                throw new IOException("File is empty.");
            }

            while (reader.PeekChar() != -1)
            {
                listAccounts.Add(new Account(
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadDouble(),
                    reader.ReadInt32(),
                    (GradingType)reader.ReadInt32()));
            }

            reader.Close();
            file.Close();

            return listAccounts;
        }

        /// <summary>
        /// Writes the collection to a file.
        /// </summary>
        /// <param name="listAccounts">The collection of accounts.</param>
        public static void WriteDataToFile(List<Account> listAccounts)
        {
            if (ReferenceEquals(null, listAccounts))
            {
                throw new ArgumentNullException(nameof(listAccounts));
            }

            FileStream file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            for (int i = 0; i < listAccounts.Count; i++)
            {
                writer.Write(listAccounts.ElementAt(i).Number);
                writer.Write(listAccounts.ElementAt(i).OwnerName);
                writer.Write(listAccounts.ElementAt(i).OwnerSurname);
                writer.Write(listAccounts.ElementAt(i).Amount);
                writer.Write(listAccounts.ElementAt(i).BonusPoints);
                writer.Write((int)listAccounts.ElementAt(i).TypeGrading);
            }

            writer.Close();
            file.Close();
        }

        #endregion Method for working with file
    }
}
