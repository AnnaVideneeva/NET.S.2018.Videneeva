using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by sum elements. 
    /// </summary>
    public class ComparerBySumElementsOfRowsIncr : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays by the sum of elements.
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>A positive number if the sum of the elements of the first array 
        /// is greater than the second, otherwise negative. 
        /// If the sums of the elements are equal, 0 is returned.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            return firstArray.Sum() - secondArray.Sum();
        }
    }
}
