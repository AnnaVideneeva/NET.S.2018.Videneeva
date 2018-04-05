using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// Provides methods for sorting a bubble.
    /// </summary>
    public class BubbleSortDelegate
    {
        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        public static void Sort(int[][] array, Comparison<int[]> comparison)
        {
            Validator.ValidateArray(array);
            Validator.ValidateComparison(comparison);

            SortJaggedArray(array, new DelegateAdapter(comparison));
        }

        /// <summary>
        /// Sorts the jagged array.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        private static void SortJaggedArray(int[][] array, IComparer<int[]> comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swaps two elements.
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] temp = firstArray;
            firstArray = secondArray;
            secondArray = temp;
        }
    }
}
