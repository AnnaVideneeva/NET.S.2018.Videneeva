namespace Books.EqualityComparers
{
    /// <summary>
    /// Provides a method to support the comparison of objects for equality.
    /// </summary>
    public interface IEqualityComparer
    {
        /// <summary>
        /// Compares the object Book with the given string.
        /// </summary>
        /// <param name="book">A book.</param>
        /// <param name="str">A value for comparison.</param>
        /// <returns>True if the objects are equal, otherwise - false.</returns>
        bool Equals(Book book, string str);
    }
}