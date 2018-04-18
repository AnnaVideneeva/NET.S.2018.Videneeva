using System;

namespace BinaryTree.Tests
{
    /// <summary>
    /// Provides methods for working with a book.
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>
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

        #region Overridden methods

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashcode = this.Author.GetHashCode();
            hashcode = (11 * hashcode) + this.Title.GetHashCode();
            return hashcode;
        }

        #endregion Overridden methods

        #region IEquatable interface implementation

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Author.Equals(other.Author)
                && this.Title.Equals(other.Title);
        }

        #endregion IEquatable interface implementation

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