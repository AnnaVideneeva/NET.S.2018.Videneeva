using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Tests
{
    [TestClass]
    class SortingMSTests
    {
        #region QuickSort

        [TestMethod]
        public void QuickSort_SuccessfulExecution()
        {
            int[] originalArray = new int[] { 4, 3, 1, 6, 8, 2, 1 };
            int[] sortingArray = new int[] { 1, 1, 2, 3, 4, 6, 8 };

            Sorting.QuickSort(originalArray);

            CollectionAssert.AreEqual(originalArray, sortingArray);
        }

        #endregion QuickSort

        #region MergeSort

        [TestMethod]
        public void MergeSort_SuccessfulExecution()
        {
            int[] originalArray = new int[] { 4, 3, 9, 1, 6, 8, 2, 1 };
            int[] sortingArray = new int[] { 1, 1, 2, 3, 4, 6, 8, 9 };

            originalArray = Sorting.MergeSort(originalArray);

            CollectionAssert.AreEqual(originalArray, sortingArray);
        }

        #endregion MergeSort
    }
}
