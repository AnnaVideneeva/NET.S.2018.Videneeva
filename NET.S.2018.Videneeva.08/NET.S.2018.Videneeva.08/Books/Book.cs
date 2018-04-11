using System;
using System.Collections.Generic;
using System.Globalization;
using Books.Comparers;
using NLog;

namespace Books
{
    /// <summary>
    /// Provides properties and methods for working with the book.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>, IFormattable
    {
        #region Fields
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private string _isbn;
        private string _author;
        private string _name;
        private string _publishingHouse;
        private int _yearOfPublishing;
        private int _numberOfPages;
        private decimal _price;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="isbn">International Standard Book Number of the book.</param>
        /// <param name="author">Author of the book.</param>
        /// <param name="name">Book title.</param>
        /// <param name="publishingHouse">Publisher of the book./</param>
        /// <param name="yearOfPublishing">Year of publication of the book.</param>
        /// <param name="numberOfPages">Number of pages in the book.</param>
        /// <param name="price">The price of the book.</param>
        public Book(string isbn, string author, string name, string publishingHouse, int yearOfPublishing, int numberOfPages, decimal price)
        {
            ISBN = isbn;
            Author = author;
            Name = name;
            PublishingHouse = publishingHouse;
            YearOfPublishing = yearOfPublishing;
            NumberOfPages = numberOfPages;
            Price = price;

            Logger.Info("The object of the Book class was successfully created.");
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// International Standard Book Number of the book.
        /// </summary>
        public string ISBN
        {
            get
            {
                return _isbn;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    Logger.Warn("The argument of ISBN is null.");
                    throw new ArgumentNullException(nameof(value));
                }

                _isbn = value;
                Logger.Info("The field value of ISBN is set to { 0 }", value);
            }
        }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    Logger.Warn("The argument of Author is null.");
                    throw new ArgumentNullException(nameof(value));
                }

                _author = value;
                Logger.Info("The field value of Author is set to { 0 }", value);
            }
        }

        /// <summary>
        /// Book title.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    Logger.Warn("The argument of Name is null.");
                    throw new ArgumentNullException(nameof(value));
                }

                _name = value;
                Logger.Info("The field value of Name is set to { 0 }", value);
            }
        }

        /// <summary>
        /// Publisher of the book.
        /// </summary>
        public string PublishingHouse
        {
            get
            {
                return _publishingHouse;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    Logger.Warn("The argument of PublishingHouse is null.");
                    throw new ArgumentNullException(nameof(value));
                }

                _publishingHouse = value;
                Logger.Info("The field value of PublishingHouse is set to { 0 }", value);
            }
        }

        /// <summary>
        /// Year of publication of the book.
        /// </summary>
        public int YearOfPublishing
        {
            get
            {
                return _yearOfPublishing;
            }

            set
            {
                if (value <= 0 && value > 2018)
                {
                    Logger.Warn("The argument of YearOfPublishing is not correct (less than 0 or more than this year).");
                    throw new ArgumentException(nameof(value));
                }

                _yearOfPublishing = value;
                Logger.Info("The field value of YearOfPublishing is set to { 0 }", value);
            }
        }

        /// <summary>
        /// Number of pages in the book.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return _numberOfPages;
            }

            set
            {
                if (value <= 0)
                {
                    Logger.Warn("The argument of  NumberOfPages is  not correct (less than 0).");
                    throw new ArgumentException(nameof(value));
                }

                _numberOfPages = value;
                Logger.Info("The field value of NumberOfPages is set to { 0 }", value);
            }
        }

        /// <summary>
        /// The price of the book.
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value <= 0)
                {
                    Logger.Warn("The argument of Price is not correct (less than 0).");
                    throw new ArgumentException(nameof(value));
                }

                _price = value;
                Logger.Info("The field value of Price is set to { 0 }", value);
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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>The string of a data about book.</returns>
        public override string ToString()
        {
            return $"ISBN: {ISBN};\nAuthor: {Author};\nName: {Name};\nPublishing House: {PublishingHouse};\nYear: {YearOfPublishing};\nNumber of pages: {NumberOfPages};\nPrice: {Price}.";
        }

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashcode = ISBN.GetHashCode();
            hashcode = (11 * hashcode) + Author.GetHashCode();
            hashcode = (11 * hashcode) + Name.GetHashCode();
            hashcode = (11 * hashcode) + PublishingHouse.GetHashCode();
            hashcode = (11 * hashcode) + YearOfPublishing.GetHashCode();
            hashcode = (11 * hashcode) + NumberOfPages.GetHashCode();
            hashcode = (11 * hashcode) + Price.GetHashCode();
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

            return ISBN.Equals(other.ISBN)
                && Name.Equals(other.Name)
                && Author.Equals(other.Author)
                && PublishingHouse.Equals(other.PublishingHouse)
                && YearOfPublishing.Equals(other.YearOfPublishing)
                && NumberOfPages.Equals(other.NumberOfPages)
                && Price.Equals(other.Price);
        }

        #endregion IEquatable interface implementation

        #region IComparable interface implementation

        /// <summary>
        /// Compares the current instance to another object and returns an integer 
        /// that indicates whether the current instance is before, after, 
        /// or at the same position in the sort order as the other object by the ISBN criteria.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value indicating whether one is less than, equal to, or greater than the other.</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }
            else
            {      
                return ComparerFactory.GetComparer(Tag.Isbn).Compare(this, other);
            }
        }

        /// <summary>
        /// Compares the current instance with another object and returns an integer 
        /// that indicates whether the current instance is before, after, 
        /// or at the same position in the sort order that the other object is by a certain criterion.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <param name="tag">Criterion for comparison.</param>
        /// <returns>A value indicating whether one is less than, equal to, or greater than the other.</returns>
        public int CompareTo(Book other, Tag tag)
        {
            if (tag == 0)
            {
                Logger.Error("The argument of tag is 0.");
                throw new ArgumentException(nameof(tag));
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }
            else
            {
                return ComparerFactory.GetComparer(tag).Compare(this, other);
            }
        }

        #endregion IComparable interface implementation

        #region IFormattable interface implementation

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">Format of the string representation.</param>
        /// <param name="formatProvider">The provider to use to format the value.</param>
        /// <returns>The value of the current instance in the specified format</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format is null)
            {
                format = "IANPYNP";
            }

            if (formatProvider is null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }
               
            switch (format.ToUpperInvariant())
            {
                case "AN":
                    {
                        return $"Author: {Author};\nName: {Name}.";
                    }

                case "ANPY":
                    {
                        return $"Author: {Author};\nName: {Name};\nPublishing House: {PublishingHouse};\nYear: {YearOfPublishing}.";
                    }

                case "IANPYN":
                    {
                        return $"ISBN: {ISBN};\nAuthor: {Author};\nName: {Name};\nPublishing House: {PublishingHouse};\nYear: {YearOfPublishing};\nNumber of pages: {NumberOfPages}.";
                    }   
                    
                case "IANPYNP":
                    {
                        return $"ISBN: {ISBN};\nAuthor: {Author};\nName: {Name};\nPublishing House: {PublishingHouse};\nYear: {YearOfPublishing};\nNumber of pages: {NumberOfPages};\nPrice: {Price}.";
                    }  
                    
                default:
                    {
                        throw new FormatException(string.Format("The {0} format string is not supported.", format));
                    }       
            }
        }
        #endregion IFormattable interface implementation
    }
}