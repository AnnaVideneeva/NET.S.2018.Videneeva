using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Class Sorting contains two methods, which sort array of type int: QuickSort and MergeSort.
    /// </summary>
    public class Sorting
    {
        #region QuickSort

        /// <summary>
        /// Method QuickSort sorts passes control to the method for sorting.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        public static void QuickSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method QuickSort sorts items in ascending order.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        /// <param name="start">Start of array.</param>
        /// <param name="end">End of array.</param>
        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int indexResolvingElement = ArrayPartitioning(array, start, end);

            QuickSort(array, start, indexResolvingElement - 1);
            QuickSort(array, indexResolvingElement + 1, end);
        }

        /// <summary>
        /// Method ArrayPartitioning find index resolving element.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        /// <param name="start">Start of array.</param>
        /// <param name="end">End of array.</param>
        /// <returns>Index resolving element.</returns>
        private static int ArrayPartitioning(int[] array, int start, int end)
        {
            int index = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    Swap(ref array[index], ref array[i]);
                    index += 1;
                }
            }
            return index - 1;
        }

        /// <summary>
        /// Method Swap swaps two elements.
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        #endregion QuickSort

        #region MergeSort

        /// <summary>
        /// Method MergeSort sorts items in ascending order.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        /// <returns>Sorted array.</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middleIndex = array.Length / 2;
            return Merge(MergeSort(array.Take(middleIndex).ToArray()), MergeSort(array.Skip(middleIndex).ToArray()));
        }

        /// <summary>
        /// Method Merge combines two arrays, arranging the elements in ascending order
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns>An array consisting of two incoming arrays.</returns>
        private static int[] Merge(int[] firstArray, int[] secondArray)
        {
            int a = 0, b = 0;
            int[] mergedArray = new int[firstArray.Length + secondArray.Length];

            for (int i = 0; i < firstArray.Length + secondArray.Length; i++)
            {
                if (b < secondArray.Length && a < firstArray.Length)
                {
                    if (firstArray[a] > secondArray[b])
                    {
                        mergedArray[i] = secondArray[b++];
                    }
                    else
                    {
                        mergedArray[i] = firstArray[a++];
                    }
                }
                else
                {
                    if (b < secondArray.Length)
                    {
                        mergedArray[i] = secondArray[b++];
                    }
                    else
                    {
                        mergedArray[i] = firstArray[a++];
                    }
                }
            }
            return mergedArray;
        }

        #endregion MergeSort
    }
}
