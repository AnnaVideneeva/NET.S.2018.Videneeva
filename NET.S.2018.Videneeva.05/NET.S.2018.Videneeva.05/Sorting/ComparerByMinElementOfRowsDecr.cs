﻿using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by min element.
    /// </summary>
    public class ComparerByMinElementOfRowsDecr : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays by the minimum element.
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>A positive number if the minimum element of the second array 
        /// is greater than the first, otherwise negative. 
        /// If the sums of the elements are equal, 0 is returned.</returns>
        public int Compare(int[] firstArray, int[] secondArray)
        {
            return secondArray.Min() - firstArray.Min();
        }
    }
}

