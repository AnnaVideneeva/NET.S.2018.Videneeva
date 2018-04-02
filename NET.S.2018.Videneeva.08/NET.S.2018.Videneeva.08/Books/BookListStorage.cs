﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Books
{
    /// <summary>
    /// Provides methods for working with the data store.
    /// </summary>
    public class BookListStorage
    {
        #region Fields

        private string _path;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The path to the file with the collection of books.
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _path = value;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BookListStorage() : this(AppDomain.CurrentDomain.BaseDirectory + "BookListStorage.txt") { }

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="path">The path to the file with the collection of books.</param>
        public BookListStorage(string path)
        {
            Path = path;
        }

        #endregion Constructors

        #region Method for working with file

        /// <summary>
        /// Reads book data from a file and creates a collection.
        /// </summary>
        /// <returns>The collection of books.</returns>
        public List<Book> ReadDataFromFile()
        {
            var listBook = new List<Book>();

            FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);

            if (reader.PeekChar() == -1)
            {
                throw new IOException("File is empty.");
            }

            while (reader.PeekChar() != -1)
            {
                listBook.Add(new Book(
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadInt32(),
                    reader.ReadInt32(),
                    reader.ReadDecimal()
                    ));
            }

            reader.Close();
            file.Close();

            return listBook;
        }

        /// <summary>
        /// Writes the collection to a file.
        /// </summary>
        /// <param name="listBook">The collection of books.</param>
        public void WriteDataToFile(List<Book> listBook)
        {
            if (ReferenceEquals(null, listBook))
            {
                throw new ArgumentNullException(nameof(listBook));
            }

            FileStream file = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            for (int i = 0; i < listBook.Count; i++)
            {
                writer.Write(listBook.ElementAt(i).ISBN);
                writer.Write(listBook.ElementAt(i).Author);
                writer.Write(listBook.ElementAt(i).Name);
                writer.Write(listBook.ElementAt(i).PublishingHouse);
                writer.Write(listBook.ElementAt(i).YearOfPublishing);
                writer.Write(listBook.ElementAt(i).NumberOfPages);
                writer.Write(listBook.ElementAt(i).Price);
            }

            writer.Close();
            file.Close();
        }

        #endregion Method for working with file
    }
}
