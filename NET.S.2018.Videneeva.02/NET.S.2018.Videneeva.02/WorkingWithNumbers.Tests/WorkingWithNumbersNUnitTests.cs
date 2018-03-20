using NUnit.Framework;
using System;

namespace WorkingWithNumbers.Tests
{
    [TestFixture]
    class WorkingWithNumbersNUnitTests
    {
        #region InsertNumber

        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(15, 10, 1, 3, ExpectedResult = 5)]
        [TestCase(10, 15, 1, 3, ExpectedResult = 14)]
        public int InsertNumber_SuccessfulExecution(int firstNumber, int secondNumber, int i, int j)
        {
            return WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j);
        }

        [TestCase(8, 15, -3, 8)]
        [TestCase(8, 15, 0, -6)]
        [TestCase(15, 15, 70, 0)]
        public void InsertNumber_ArgumentOutOfRangeException(int firstNumber, int secondNumber, int i, int j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j));
        }

        [TestCase(8, 15, 9, 8)]
        public void InsertNumber_ArgumentException(int firstNumber, int secondNumber, int i, int j)
        {
            Assert.Throws<ArgumentException>(() => WorkingWithNumbers.InsertNumber(firstNumber, secondNumber, i, j));
        }

        #endregion InsertNumber

        #region FindNextBiggerNumber

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(35, ExpectedResult = 53)]
        [TestCase(789, ExpectedResult = 798)]
        [TestCase(202, ExpectedResult = 220)]
        [TestCase(1789, ExpectedResult = 1798)]
        [TestCase(155, ExpectedResult = 515)]
        [TestCase(873645, ExpectedResult = 873654)]
        public int FindNextBiggerNumber_SuccessfulExecution(int number)
        {
            long timeFindNextBiggerNumber;
            return WorkingWithNumbers.FindNextBiggerNumber(number, out timeFindNextBiggerNumber);
        }

        [TestCase(98765, ExpectedResult = -1)]
        [TestCase(55, ExpectedResult = -1)]
        [TestCase(1000, ExpectedResult = -1)]
        public int FindNextBiggerNumber_UnsuccessfulExecution(int number)
        {
            long timeFindNextBiggerNumber;
            return WorkingWithNumbers.FindNextBiggerNumber(number, out timeFindNextBiggerNumber);
        }

        #endregion FindNextBiggerNumber

        #region FilterDigit

        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 1, ExpectedResult = new int[] { 12, 11 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 2, ExpectedResult = new int[] { 12, 23, 22, 24 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 3, ExpectedResult = new int[] { 34, 23, 38 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 4, ExpectedResult = new int[] { 34, 64, 40, 24, 64 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 5, ExpectedResult = new int[] { 56, 5, 57 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 6, ExpectedResult = new int[] { 56, 64, 68, 69, 64 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 7, ExpectedResult = new int[] { 70, 57 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 8, ExpectedResult = new int[] { 89, 68, 38 })]
        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 9, ExpectedResult = new int[] { 89, 69, 90 })]
        public int[] FilterDigit_SuccessfulExecution(int[] array, int digit)
        {
            return WorkingWithNumbers.FilterDigit(array, digit);
        }

        [TestCase(new int[0], 9)]
        public void FilterDigit_ArgumentOutOfRangeException(int[] array, int digit)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WorkingWithNumbers.FilterDigit(array, digit));
        }

        [TestCase(new int[] { 56, 12, 11, 89, 34, 23, 64, 68, 69, 70, 22, 38, 40, 5, 57, 24, 90, 64 }, 99)]
        public void FilterDigit_ArgumentException(int[] array, int digit)
        {
            Assert.Throws<ArgumentException>(() => WorkingWithNumbers.FilterDigit(array, digit));
        }

        #endregion FilterDigit

        #region FindNthRoot

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_SuccessfulExecution(double number, int degree, double accuracy)
        {
            return WorkingWithNumbers.FindNthRoot(number, degree, accuracy);
        }

        [TestCase(0.0081, -4, 0.1)]
        [TestCase(-0.008, 8, 0.1)]
        [TestCase(0.008, 3, 67)]
        public void FindNthRoot_ArgumentOutOfRangeException(double number, int degree, double accuracy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WorkingWithNumbers.FindNthRoot(number, degree, accuracy));
        }

        #endregion FindNthRoot
    }
}
