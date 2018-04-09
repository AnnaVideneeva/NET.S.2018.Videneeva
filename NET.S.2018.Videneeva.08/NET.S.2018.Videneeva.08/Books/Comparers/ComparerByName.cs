using System.Collections.Generic;

namespace Books.Comparers
{
    /// <summary>
    /// Provides a method for comparing two objects of the Book class on the Name field.
    /// </summary>
    public class ComparerByName : IComparer<Book>
    {
        /// <summary>
        /// Performs a comparison of two objects of the Book class 
        /// and returns a value indicating whether one object is less than, 
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="lhs">A first object for comparison.</param>
        /// <param name="rhs">A second object for comparison.</param>
        /// <returns>A positive number if one book is larger than the other, otherwise it is negative. 
        /// If are equal, 0 is returned.</returns>
        public int Compare(Book lhs, Book rhs)
        {
            return lhs.Name.CompareTo(rhs.Name);
        }
    }
}