using System.Collections.Generic;

namespace Books.Comparers
{
    /// <summary>
    /// Provides a method for comparing two objects of the Book class on the YearOfPublishing field.
    /// </summary>
    public class ComparerByYearOfPublishing : IComparer<Book>
    {
        /// <summary>
        /// Performs a comparison of two objects of the Book class 
        /// and returns a value indicating whether one object is less than, 
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="lhs">A first object for comparison.</param>
        /// <param name="rhs">A second object for comparison.</param>
        /// <returns>A positive number if the current book is greater, otherwise negative. 
        /// If are equal, 0 is returned.</returns>
        public int Compare(Book lhs, Book rhs)
        {
            return lhs.YearOfPublishing - rhs.YearOfPublishing;
        }
    }
}
