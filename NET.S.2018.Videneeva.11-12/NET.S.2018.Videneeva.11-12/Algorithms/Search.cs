using System;
using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// Provides methods for finding an element in an array.
    /// </summary>
    public class Search
    {
        #region Public methods

        /// <summary>
        /// Performs a binary search for <paramref name="array"/> in <paramref name="searchElemen"/>.
        /// </summary>
        /// <typeparam name="T">>Generalization for use of any type.</typeparam>
        /// <param name="array">An array.</param>
        /// <param name="searchElemen">The desired element.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="array"/> is not sorted.</exception>
        /// <returns>Returns the index of the element in the array, if it is found, otherwise -1.</returns>
        public static int BinarySearch<T>(T[] array, T searchElemen)
        {
            if (ReferenceEquals(null, array))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (!array.IsSort(Comparer<T>.Default))
            {
                throw new ArgumentException(nameof(array), "Array is not sorted!");
            }

            return BinarySearch<T>(array, searchElemen, Comparer<T>.Default);
        }

        #endregion Public methods

        #region Private methods

        private static int BinarySearch<T>(T[] array, T searchElement, IComparer<T> comparer)
        {
            int firstIndex = 0;
            int lastIndex = array.Length - 1;
            int middleIndex;
            while (firstIndex <= lastIndex)
            {
                middleIndex = firstIndex + ((lastIndex - firstIndex) / 2);

                if (comparer.Compare(searchElement, array[middleIndex]) < 0)
                {
                    lastIndex = middleIndex - 1;
                }
                else if (comparer.Compare(searchElement, array[middleIndex]) > 0)
                {
                    firstIndex = middleIndex + 1;
                }
                else
                {
                    return middleIndex;
                }
            }

            return -1;
        }

        #endregion Private methods
    }
}