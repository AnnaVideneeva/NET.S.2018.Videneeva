﻿using System;
using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    public class BubbleSortNUnitTests
    {
        #region Sorting by sum elements of rows

        [Test]
        public void SortingBySumElementsOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 1 }, new[] { -6, 11, 5 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSort.SortIncr(jaggedArray, new ComparerBySumElementsOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingBySumElementsOfRowsDecr_SuccessfulExecution( )
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new int[] { 44, 39 }, new int[] { 38, 4 }, new int[] { -6, 11, 5 }, new[] { 1 } };

            BubbleSort.SortDecr(jaggedArray, new ComparerBySumElementsOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by sum elements of rows

        #region Sorting by min element of rows

        [Test]
        public void SortingByMinElementOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { -6, 11, 5 }, new[] { 1 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSort.SortIncr(jaggedArray, new ComparerByMinElementOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingByMinElementOfRowsDecr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 44, 39 }, new[] { 38, 4 }, new[] { 1 }, new[] { -6, 11, 5 } };

            BubbleSort.SortDecr(jaggedArray, new ComparerByMinElementOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by min element of rows

        #region Sorting by max element of rows

        [Test]
        public void SortingByMaxElementOfRowsIncr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 1 }, new[] { -6, 11, 5 }, new[] { 38, 4 }, new[] { 44, 39 } };

            BubbleSort.SortIncr(jaggedArray, new ComparerByMaxElementOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        [Test]
        public void SortingByMaxElementOfRowsDecr_SuccessfulExecution()
        {
            int[][] jaggedArray = { new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 44, 39 }, new[] { 1 } };
            int[][] expectedJaggetArray = { new[] { 44, 39 }, new[] { 38, 4 }, new[] { -6, 11, 5 }, new[] { 1 } };

            BubbleSort.SortDecr(jaggedArray, new ComparerByMaxElementOfRows());

            Assert.AreEqual(jaggedArray, expectedJaggetArray);
        }

        #endregion Sorting by max element of rows
    }
}