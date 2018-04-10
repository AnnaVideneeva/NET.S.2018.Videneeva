using Books.Comparers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    /// <summary>
    /// Provides methods for working with the collection of books.
    /// </summary>
    public class BookListService
    {
        #region Fields

        private List<Book> _listBook;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Collection of books.
        /// </summary>
        public List<Book> ListBook
        {
            get
            {
                return _listBook;
            }
            private set
            {
                if (ReferenceEquals(null, value))
                {
                    logger.Warn("The argument of ListBook is null.");
                    throw new ArgumentNullException(nameof(value));
                }

                _listBook = value;
                logger.Info("The field value of ListBook is set to { 0 }", value);
            }
        }

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return _listBook.Count;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="listBook">Collection of books.</param>    
        public BookListService(List<Book> listBook)
        {
            ListBook = listBook;

            logger.Info("The object of the BookListService class was successfully created.");
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BookListService() : this(new List<Book>())
        {
            logger.Info("The object of the BookListService class was successfully created.");
        }

        #endregion Constructors

        #region Public methods for working with list of books

        /// <summary>
        /// Adds a new book to an existing collection.
        /// </summary>
        /// <param name="book">A new book.</param>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="book"/> is null.</exception>
        /// <exception cref="DuplicateWaitObjectException">Throw when a book with such data already exists.</exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                logger.Warn("The value argument of Book is null.");
                throw new ArgumentNullException(nameof(book));
            }

            if (ListBook.Contains(book))
            {   
                logger.Warn("A book with such data already exists.");
                throw new DuplicateWaitObjectException(nameof(book));
            }

            ListBook.Add(book);
            logger.Info("A new book was added.");
        }

        /// <summary>
        /// Removes a book from an existing collection.
        /// </summary>
        /// <param name="book">A book to remove from the collection.</param>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="book"/> is null.</exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                logger.Error("The value argument of Book is null.");
                throw new ArgumentNullException(nameof(book));
            }

            if (ListBook.Remove(book))
            {
                logger.Info("The book was removed.");
            }
            else
            {
                logger.Warn("The book was not removed.");
            }    
        }

        /// <summary>
        /// Searches for an element that satisfies the conditions of the specified criterion 
        /// and value, and returns the first occurrence found within the entire collection.
        /// </summary>
        /// <param name="tag">Criterion for the search.</param>
        /// <param name="value">The value to search.</param>
        /// <exception cref="ArgumentNullException">Called when <paramref name="value"/> is null.</exception>
        /// <exception cref="NullReferenceException">Throw when comparer with <paramref name="tag"> is not found.</exception>
        /// <returns>The first element that satisfies the conditions, if such an element is found; 
        /// otherwise, the line with the message.</returns>
        public string FindBookByTag(Tag tag, string value)
        {
            if (ReferenceEquals(null, value))
            {
                logger.Warn("The value argument is null.");
                throw new ArgumentNullException(nameof(value));
            }

            var equalityComparer = EqualityComparerFactory.GetEqualityComparer(tag) 
                ?? throw new NullReferenceException("EqualityComparer with that tag is not found.");

            for (int i = 0; i < ListBook.Count; i++)
            {
                if (equalityComparer.Equals(ListBook.ElementAt(i), value))
                {
                    logger.Info("A book on the criterion {0} with the value {1} was found.", tag, value);
                    return ListBook.ElementAt(i).ToString();
                }
            }

            logger.Info("A book on the criterion {0} with the value {1} was not found.", tag, value);
            return $"There is no such book!";
        }

        /// <summary>
        /// Sorts the elements of the collection according to the specified criteria.
        /// </summary>
        /// <param name="tag">Criterion for the search.</param>
        /// <exception cref="NullReferenceException">Throw when comparer with <paramref name="tag"> is not found.</exception>
        public void SortBooksByTag(Tag tag)
        {
            var comparer = ComparerFactory.GetComparer(tag) 
                ?? throw new NullReferenceException("Comparer with that tag is not found.");

            for (int i = 0; i < ListBook.Count; i++)
            {
                for (int j = 0; j < ListBook.Count - i - 1; j++)
                {
                    if (comparer.Compare(ListBook.ElementAt(j), ListBook.ElementAt(j + 1)) > 0)
                    {
                        var temp = ListBook.ElementAt(j + 1);

                        ListBook.RemoveAt(j + 1);
                        ListBook.Insert(j + 1, ListBook.ElementAt(j));

                        ListBook.RemoveAt(j);
                        ListBook.Insert(j, temp);
                    }
                }
            }

            logger.Info("The ListBook is sorted by criteria {0}.", tag);
        }

        #endregion Public methods for working with list of books

        #region Public methods for writing to/reading from a file

        /// <summary>
        /// Writes the collection to a file.
        /// </summary>
        public void WriteDataToFile()
        {
            (new BookListStorage()).WriteDataToFile(ListBook);
        }

        /// <summary>
        /// Reads book data from a file.
        /// </summary>
        public void ReadDataFromFile()
        {
            ListBook = (new BookListStorage()).ReadDataFromFile();
        }

        #endregion Public methods for writing to/reading from a file  
    }
}
