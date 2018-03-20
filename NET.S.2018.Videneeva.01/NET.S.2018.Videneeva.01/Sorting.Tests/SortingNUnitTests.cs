using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    class SortingNUnitTests
    { 
        #region QuickSort

        [TestCase(new int[] { 23, 2, 0, -4, 76, 8 }, ExpectedResult = new int[] { -4, 0, 2, 8, 23, 76 })]
        [TestCase(new int[] { 4, 65, 34, -4, 5, -50 }, ExpectedResult = new int[] { -50, -4, 4, 5, 34, 65 })]
        [TestCase(new int[] { 0, 34, 6, -49, 45, 8 }, ExpectedResult = new int[] { -49, 0, 6, 8, 34, 45 })]
        [TestCase(new int[] { 2364, 2343, 23, -876, 7346, 834, 34, 0 }, ExpectedResult = new int[] { -876, 0, 23, 34, 834, 2343, 2364, 7346 })]
        public int[] QuickSort_SuccessfulExecution(int[] array)
        {
            Sorting.QuickSort(array);
            return array;
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 4 }, ExpectedResult = new int[] { 4 })]
        public int[] QuickSort_UnsuccessfulExecution(int[] array)
        {
            Sorting.QuickSort(array);
            return array;
        }

        #endregion QuickSort

        #region MergeSort

        [TestCase(new int[] { 23, 2, 0, -4, 76, 8 }, ExpectedResult = new int[] { -4, 0, 2, 8, 23, 76 })]
        [TestCase(new int[] { 4, 65, 34, -4, 5, -50 }, ExpectedResult = new int[] { -50, -4, 4, 5, 34, 65 })]
        [TestCase(new int[] { 0, 34, 6, -49, 45, 8 }, ExpectedResult = new int[] { -49, 0, 6, 8, 34, 45 })]
        [TestCase(new int[] { 2364, 2343, 23, -876, 7346, 834, 34, 0 }, ExpectedResult = new int[] { -876, 0, 23, 34, 834, 2343, 2364, 7346 })]
        public int[] MergeSort_SuccessfulExecution(int[] array)
        {
            return Sorting.MergeSort(array);
        }

        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 4 }, ExpectedResult = new int[] { 4 })]
        public int[] MergeSort_UnsuccessfulExecution(int[] array)
        {
            return Sorting.MergeSort(array);
        }

        #endregion MergeSort
    }
}

