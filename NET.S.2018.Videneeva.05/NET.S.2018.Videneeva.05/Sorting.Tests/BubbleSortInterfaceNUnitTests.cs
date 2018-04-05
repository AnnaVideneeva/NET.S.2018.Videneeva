using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    public class BubbleSortInterfaceNUnitTests
    {
        #region Sorting by sum elements of rows

        [Test]
        public void SortingBySumElementsOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 1 }, new[] { -6, 11, 5 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerBySumElementsOfRowsIncr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingBySumElementsOfRowsDecr_SuccessfulExecution( )
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new int[] { 44, 39 }, new int[] { 38, 4 }, new int[] { -6, 11, 5 }, new[] { 1 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerBySumElementsOfRowsDecr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by sum elements of rows

        #region Sorting by min element of rows

        [Test]
        public void SortingByMinElementOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { -6, 11, 5 }, new[] { 1 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerByMinElementOfRowsIncr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingByMinElementOfRowsDecr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 44, 39 }, new[] { 38, 4 }, new[] { 1 }, new[] { -6, 11, 5 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerByMinElementOfRowsDecr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by min element of rows

        #region Sorting by max element of rows

        [Test]
        public void SortingByMaxElementOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 1 }, new[] { -6, 11, 5 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerByMaxElementOfRowsIncr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingByMaxElementOfRowsDecr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 44, 39 }, new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 1 } };

            BubbleSortInterface.Sort(jaggedArray, new ComparerByMaxElementOfRowsDecr());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by max element of rows
    }
}
