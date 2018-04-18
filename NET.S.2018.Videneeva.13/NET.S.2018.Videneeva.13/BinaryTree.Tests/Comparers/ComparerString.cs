using System.Collections.Generic;

namespace BinaryTree.Tests.Comparers
{
    /// <summary>
    /// Provides a method for comparing two objects of type string.
    /// </summary>
    public class ComparerString : IComparer<string>
    {
        /// <summary>
        /// Performs a comparison of two objects of type string
        /// and returns a value indicating whether one object is less than, 
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="lhs">A first object for comparison.</param>
        /// <param name="rhs">A second object for comparison.</param>
        /// <returns>A positive number if one string is larger than the other, otherwise it is negative.
        /// If they are equal, 0 is returned.</returns>
        public int Compare(string lhs, string rhs)
        {
            return lhs.CompareTo(rhs);
        }
    }
}
