using System;

namespace Sorting
{
    /// <summary>
    /// Defines a helper class that can be used to validate objects.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Determines whether the jagged array is valid.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <exception cref="ArgumentNullException">Throw ArgumentNullException if the jagged array is null.</exception>
        /// <exception cref="ArgumentException">Throw ArgumentException if the jagged array is empty.</exception>
        public static void ValidateArray(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null.");
            }

            if (array.Length is 0)
            {
                throw new ArgumentException(nameof(array), "Array is empty.");
            }
        }

        /// <summary>
        /// Determines whether the comparer is valid.
        /// </summary>
        /// <param name="array">The comparer.</param>
        /// <exception cref="ArgumentNullException">Throw ArgumentNullException if comparer is null.</exception>
        public static void ValidateComparer(Comparer comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer), "Comparer is null");
            }
        }
    }
}
