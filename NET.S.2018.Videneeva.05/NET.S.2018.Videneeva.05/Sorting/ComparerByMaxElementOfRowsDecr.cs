using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by max element.
    /// </summary>
    public class ComparerByMaxElementOfRowsDecr : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays by the maximum element..
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>A positive number if the maximum element of the second array 
        /// is greater than the first, otherwise negative. 
        /// If the sums of the elements are equal, 0 is returned.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            return secondArray.Max() - firstArray.Max();
        }
    }
}
