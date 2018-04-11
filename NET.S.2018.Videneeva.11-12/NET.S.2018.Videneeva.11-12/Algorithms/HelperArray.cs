using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// Provides an extension method for working with arrays.
    /// </summary>
    public static class HelperArray
    {
        /// <summary>
        /// Checks whether the array is sorted in ascending order.
        /// </summary>
        /// <typeparam name="T">Generalization for use of any type.</typeparam>
        /// <param name="array">An array.</param>
        /// <param name="comparer">A comparer for type T.</param>
        /// <returns>True if the array is sorded, otherwise - false.</returns>
        public static bool IsSort<T>(this T[] array, IComparer<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
