using System;
using System.Collections.Generic;

namespace BinaryTree.Tests.Comparers
{
    /// <summary>
    /// Provides a method for comparing two objects of the Point struct.
    /// </summary>
    public class ComparerPoint : IComparer<Point>
    {
        /// <summary>
        /// Performs a comparison of two objects of the Point struct 
        /// and returns a value indicating whether one object is less than, 
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="lhs">A first object for comparison.</param>
        /// <param name="rhs">A second object for comparison.</param>
        /// <returns>A positive number if one Point is larger than the other, otherwise it is negative.
        /// If they are equal, 0 is returned.</returns>
        public int Compare(Point lhs, Point rhs)
        {
            double vectorLhs = Math.Sqrt(Math.Pow(lhs.X, 2) + Math.Pow(lhs.Y, 2));
            double vectorRhs = Math.Sqrt(Math.Pow(rhs.X, 2) + Math.Pow(rhs.Y, 2));

            if (vectorLhs == vectorRhs)
            {
                return 0;
            }

            if (vectorLhs < vectorRhs)
            {
                return -1;
            }

            return 1;
        }
    }
}
