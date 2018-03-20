using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorkingWithNumbers
{
    /// <summary>
    /// This class contains methods for working with numbers.
    /// </summary>
    public class WorkingWithNumbers
    {
        #region InsertNumber

        /// <summary>
        /// An algorithm for inserting bits from the jth to the i-th bit of one number 
        /// into another so that the bits of the second number occupy positions 
        /// from bit i to bit i.
        /// </summary>
        /// <param name="firstNumber">Number for insert.</param>
        /// <param name="secondNumber">Number to insert.</param>
        /// <param name="i">To positin.</param>
        /// <param name="j">From position.</param>
        /// <returns>A result of insert.</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            CheckBitPosition(i, j);

            BitArray fisrtArray = new BitArray(new[] { firstNumber });
            BitArray secondArray = new BitArray(new[] { secondNumber });

            for (int iteratorI = i, iteratorJ = 0; iteratorI <= j; iteratorI++, iteratorJ++)
            {
                if (fisrtArray[iteratorI])
                {
                    fisrtArray[iteratorI] = fisrtArray[iteratorI] & secondArray[iteratorJ];
                }
                else
                {
                    fisrtArray[iteratorI] = fisrtArray[iteratorI] | secondArray[iteratorJ];
                }
            }

            return FromBitArrayToInt(fisrtArray);
        }

        /// <summary>
        /// This method checks bit position for correctness.
        /// </summary>
        /// <param name="i">To positin.</param>
        /// <param name="j">From position.</param>
        /// <exception cref="ArgumentOutOfRangeException">If i or j are not in range of 0 and 31.</exception>
        /// <exception cref="ArgumentException">If i bigger than j.</exception>
        private static void CheckBitPosition(int i, int j)
        {
            if (i < 0 || j < 0 || i > 31 || j > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect bit positions.");
            }

            if (i > j)
            {
                throw new ArgumentException("Incorrect bit positions.");
            }
        }

        /// <summary>
        /// This method conver BitArray to int number.
        /// </summary>
        /// <param name="bitArray">BitArray for converting.</param>
        /// <exception cref="ArgumentException">If length of bitArray more than 32.</exception>
        /// <returns>A result of converting.</returns>
        private static int FromBitArrayToInt(BitArray bitArray)
        {
            if (bitArray.Length > 32)
            {
                throw new ArgumentException("Argument length shall be at most 32 bits.");
            }

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        #endregion InsertNumber

        #region FindNextBiggerNumber

        /// <summary>
        /// This method takes a positive integer and returns the largest integer 
        /// consisting of the digits of the original, 
        /// and returns the time of finding the specified number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <param name="timeFindNextBiggerNumber">Time of finding the number.</param>
        /// <returns>A largest integer.</returns>
        public static int FindNextBiggerNumber(int number, out long timeFindNextBiggerNumber)
        {
            int nextBiggerNumber;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            nextBiggerNumber = FindNextBiggerNumber(number);
            stopwatch.Stop();

            timeFindNextBiggerNumber = stopwatch.ElapsedMilliseconds;

            return nextBiggerNumber;
        }

        /// <summary>
        /// This method takes a positive integer and returns the largest integer 
        /// consisting of the digits of the original.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>Returns the largest integer.</returns>
        private static int FindNextBiggerNumber(int number)
        {
            int[] arrayOfNumbers = CreatArrayFromInt(number);

            int index = FindIndex(arrayOfNumbers);

            if (index < arrayOfNumbers.Length && index != -1)
            {
                Swap(ref arrayOfNumbers[index], ref arrayOfNumbers[index + 1]);
                Array.Sort(arrayOfNumbers, index + 1, arrayOfNumbers.Length - index - 1);
            }
            else
            {
                return -1;
            }

            return CreateIntFromArray(arrayOfNumbers);
        }

        /// <summary>
        /// Finds index of the numeral in the array starting 
        /// with which the number should be sorted.
        /// </summary>
        /// <param name="array">Array consisting of numerals of the source number.</param>
        /// <returns>An index of the numeral in the number starting with which the number 
        /// should be changed or -1, if this is not possible.</returns>
        private static int FindIndex(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    return i - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// This method creates array of numerals of the source number.
        /// </summary>
        /// <param name="number">The source number.</param>
        /// <returns>An array consisting of numerals of the source number.</returns>
        private static int[] CreatArrayFromInt(int number)
        {
            int[] array = new int[number.ToString().Length];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = number % 10;
                number = number / 10;
            }

            return array;
        }

        /// <summary>
        /// This method creates number from array of numerals.
        /// </summary>
        /// <param name="array">Array consisting of numerals of the source number.</param>
        /// <returns>A number from array of numerals.</returns>
        private static int CreateIntFromArray(int[] array)
        {
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                number += array[i];
                number *= 10;
            }
            return number / 10;
        }

        /// <summary>
        /// The method swaps two numbers
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        #endregion FindNextBiggerNumber

        #region FilterDigit

        /// <summary>
        /// The method takes a list of numbers and filters the list, 
        /// so that only numbers containing the given digit remain on the output.
        /// </summary>
        /// <param name="array">Array in which happen filtration.</param>
        /// <param name="digit">Value of filter.</param>
        /// <exception cref="ArgumentOutOfRangeException">If array is empty.</exception>
        /// <exception cref="ArgumentException">Digit can be only in range 0 and 9.</exception>
        /// <returns>An array in which numbers containing a digit.</returns>
        public static int[] FilterDigit(int[] array, int digit)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Array is empty.");
            }
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException("Incorrect digit.");
            }

            List<int> newArray = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().Contains(digit.ToString()))
                {
                    newArray.Add(array[i]);
                }
            }

            return newArray.ToArray();
        }

        #endregion FilterDigit

        #region FindNthRoot

        /// <summary>
        /// The method calculates the root of the nth power (n∈N) 
        /// from the number (a∈R) by the Newton method with a specified accuracy.
        /// </summary>
        /// <param name="number">Number, the root of which you need to find</param>
        /// <param name="degree">Root degree</param>
        /// <param name="doubleAccuracy">Accuracy of calculations</param>
        /// <exception cref="ArgumentOutOfRangeException">If degree is less than 0</exception>
        /// <exception cref="ArgumentException">If not correct accuracy</exception>
        /// <exception cref="ArgumentOutOfRangeException">If number is less then accuracy</exception>
        /// <returns>The root of the number</returns>
        public static double FindNthRoot(double number, int degree, double doubleAccuracy)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException("The degree must be a natural number.");
            }

            if ((number < 0) && (degree % 2 == 0))
            {
                throw new ArgumentOutOfRangeException("It is impossible to calculate a root of even degree from a negative number.");
            }

            if (doubleAccuracy > 1 || doubleAccuracy <= 0)
            {
                throw new ArgumentOutOfRangeException("Accuracy can only have values greater than 0 and less than or equal to 1.");
            }

            int intAccuracy = FindIntAccuracy(doubleAccuracy);

            double tempResult;
            double result = number;

            do
            {
                tempResult = result;
                result = tempResult - ((Math.Pow(tempResult, degree) - number) / (Math.Pow(tempResult, degree - 1) * degree));
            }
            while (Math.Abs(result - tempResult) > doubleAccuracy);

            return Math.Round(result, intAccuracy);
        }

        /// <summary>
        /// The method converts the accuracy to int.
        /// </summary>
        /// <param name="doubleAccuracy">Accuracy of calculations in the form double</param>
        /// <returns>Accuracy of calculations in the form int</returns>
        private static int FindIntAccuracy(double doubleAccuracy)
        {
            int intAccuracy = 0;
            while (doubleAccuracy < 1)
            {
                doubleAccuracy *= 10;
                intAccuracy++;
            }

            return intAccuracy;
        }

        #endregion FindNthRoot
    }
}
