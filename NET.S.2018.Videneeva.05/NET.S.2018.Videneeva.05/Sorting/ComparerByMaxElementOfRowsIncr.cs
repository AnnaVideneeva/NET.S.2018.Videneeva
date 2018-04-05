using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by max element.
    /// </summary>
    public class ComparerByMaxElementOfRowsIncr : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays by the maximum element..
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>A positive number if the maximum element  of the first array 
        /// is greater than the second, otherwise negative. 
        /// If the sums of the elements are equal, 0 is returned.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            return firstArray.Max() - secondArray.Max();
        }
    }
}
