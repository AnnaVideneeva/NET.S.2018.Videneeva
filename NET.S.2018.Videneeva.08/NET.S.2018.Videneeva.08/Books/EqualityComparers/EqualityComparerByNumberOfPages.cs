﻿namespace Books.EqualityComparers
{
    /// <summary>
    /// Provides a method for comparing the Book object with a given string to equality.
    /// </summary>
    public class EqualityComparerByNumberOfPages : IEqualityComparer
    {
        /// <summary>
        /// Compares the field NumberOfPages of the object Book with the given string.
        /// </summary>
        /// <param name="book">A book.</param>
        /// <param name="str">A given string.</param>
        /// <returns>True if the field NumberOfPages of the object Book and a given string are equal,
        /// otherwise - false.</returns>
        public bool Equals(Book book, string str)
        {
            return Equals(book.NumberOfPages.ToString(), str);
        }
    }
}