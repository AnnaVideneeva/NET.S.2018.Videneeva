using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SearchNUnitTests
    {
        #region Successful Execution

        [TestCase(new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, 5, ExpectedResult = 4)]
        public int BinarySearch_IntArray_SuccessfulExecution(int[] array, int searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new double[] { 1.0, 1.0, 2, 3, 5, 8, 13.0, 21, 34, 55.0 }, 8, ExpectedResult = 5)]
        public int BinarySearch_DoubleArray_SuccessfulExecution(double[] array, double searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'm', 'n' }, 'm', ExpectedResult = 8)]
        public int BinarySearch_CharArray_SuccessfulExecution(char[] array, char searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new string[] { "abs", "ber", "csf", "dre", "ert", "fsd" }, "dre", ExpectedResult = 3)]
        public int BinarySearch_StringArray_SuccessfulExecution(string[] array, string searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new string[] { null, "abs", "ber", "csf" }, null, ExpectedResult = 0)]
        public int BinarySearch_StringArray_SearchNull_SuccessfulExecution(string[] array, string searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        #endregion Successful Execution

        #region Unsuccessful Execution

        [TestCase(new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, 51, ExpectedResult = -1)]
        public int BinarySearch_IntArray_UnsuccessfulExecution(int[] array, int searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new double[] { 1, 1.0, 2, 3, 5, 8, 13.0, 21, 34, 55.0 }, 80, ExpectedResult = -1)]
        public int BinarySearch_DoubleArray_UnsuccessfulExecution(double[] array, double searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'i', 'm', 'n' }, 'l', ExpectedResult = -1)]
        public int BinarySearch_CharArray_UnsuccessfulExecution(char[] array, char searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        [TestCase(new string[] { "abs", "ber", "csf", "dre", "ert", "fsd" }, "ikj", ExpectedResult = -1)]
        public int BinarySearch_StringArray_UnsuccessfulExecution(string[] array, string searchElement)
        {
            return Search.BinarySearch(array, searchElement);
        }

        #endregion Unsuccessful Execution

        #region Exceptions

        [TestCase(null, 123)]
        public void BinarySearch_ArgumentNullException(int[] array, int searchElement)
        {
            Assert.Throws<ArgumentNullException>(() => Search.BinarySearch(array, searchElement));
        }

        [TestCase(new int[] { 23, 12, 45, 654 }, 123)]
        public void BinarySearch_ArgumentException(int[] array, int searchElement)
        {
            Assert.Throws<ArgumentException>(() => Search.BinarySearch(array, searchElement));
        }

        #endregion Exceptions
    }
}
