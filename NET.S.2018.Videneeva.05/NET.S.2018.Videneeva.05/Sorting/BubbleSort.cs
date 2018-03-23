namespace Sorting
{
    /// <summary>
    /// Provides methods for sorting a bubble.
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// Sorts the jagged array ascendingly.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        public static void SortIncr(int[][] array, Comparer comparer)
        {
            Validator.ValidateArray(array);
            Validator.ValidateComparer(comparer);

            SortJaggedArrayIncr(array, comparer);
        }

        /// <summary>
        /// Sorts the jagged array descendingly.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        public static void SortDecr(int[][] array, Comparer comparer)
        {
            Validator.ValidateArray(array);
            Validator.ValidateComparer(comparer);

            SortJaggedArrayDecr(array, comparer);
        }

        /// <summary>
        /// Sorts the jagged array ascendingly.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        private static void SortJaggedArrayIncr(int[][] array, Comparer comparer)
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
        /// Sorts the jagged array descendingly.
        /// </summary>
        /// <param name="array">The jagged array.</param>
        /// <param name="comparer">The criteria for sorting.</param>
        private static void SortJaggedArrayDecr(int[][] array, Comparer comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) < 0)
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
