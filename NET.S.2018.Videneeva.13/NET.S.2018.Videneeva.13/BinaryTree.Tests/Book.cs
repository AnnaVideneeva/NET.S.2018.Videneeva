using System;

namespace BinaryTree.Tests
{
    /// <summary>
    /// Provides methods for working with a book.
    /// </summary>
    public class Book : IComparable<Book>
    {
        #region Fields

        private string author;
        private string title;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inintializes a new instance of the <see cref="author"/> and <see cref="title"/>.
        /// </summary>
        /// <param name="author">The author of book.</param>
        /// <param name="title">The title of book.</param>
        public Book(string author, string title)
        {
            this.Author = author;
            this.Title = title;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Sets and gets the author of the current book.
        /// </summary>
        public string Author
        {
            get => this.author;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Sets and gets the title of the current book.
        /// </summary>
        public string Title
        {
            get => this.title;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.title = value;
            }
        }

        #endregion Properties

        #region IComparable<Book> interface implementation

        /// <summary>
        /// Performs a comparison of two objects of the Book class 
        /// and returns a value indicating whether one object is less than, 
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="other">The other book.</param>
        /// <returns>A positive number if one book is larger than the other, otherwise it is negative.
        /// If they are equal, 0 is returned.</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return string.Compare(this.Author, other.Author, StringComparison.Ordinal);
        }

        #endregion IComparable<Book> interface implementation
    }
}