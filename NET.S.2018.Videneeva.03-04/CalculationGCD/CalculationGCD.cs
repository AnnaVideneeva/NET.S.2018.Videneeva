using System;
using System.Diagnostics;
using System.Linq;

namespace CalculationGCD
{
    /// <summary>
    /// This class containts Steins and Euclids method which can find GCD.
    /// </summary>
    public class CalculationGCD
    {
        private delegate int AlgorithmCalculationGCD(int firstNumber, int secondNumber);

        #region EuclidsAlgorithm

        /// <summary>
        /// The public method calculates GCD using Euclid's algorithm.
        /// </summary>
        /// <param name="timeCalculationGCD">It's an output parameter and contains the execution time of the algorithm.</param>
        /// <param name="numbers">An array of parameters that contains numbers for finding the GCD.</param>
        /// <returns>GCD.</returns>
        public static int EuclidsAlgorithm(out long timeCalculationGCD, params int[] numbers)
        {
            return Calculation(out timeCalculationGCD, new AlgorithmCalculationGCD(EuclidsAlgorithm), numbers);
        }

        /// <summary>
        /// The private method calculates GCD for two nambers using Euclid's algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>    
        /// <returns>GCD.</returns>
        private static int EuclidsAlgorithm(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }

            return firstNumber;
        }

        #endregion EuclidsAlgorithm

        #region SteinsAlgorithm

        /// <summary>
        /// The public method calculates GCD using Stein's algorithm.
        /// </summary>
        /// <param name="timeCalculationGCD">It's an output parameter and contains the execution time of the algorithm.</param>
        /// <param name="numbers">An array of parameters that contains numbers for finding the GCD.</param>
        /// <returns>GCD.</returns>
        public static int SteinsAlgorithm(out long timeCalculationGCD, params int[] numbers)
        {
            return Calculation(out timeCalculationGCD, new AlgorithmCalculationGCD(SteinsAlgorithm), numbers);
        }

        /// <summary>
        /// The private method calculates GCD for two nambers using Stein's algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>    
        /// <returns>GCD.</returns>
        private static int SteinsAlgorithm(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if ((firstNumber == 1) || (secondNumber == 1))
            {
                return 1;
            }

            if (firstNumber % 2 == 0)
            {
                return (secondNumber % 2 == 0)
                    ? (2 * SteinsAlgorithm(firstNumber / 2, secondNumber / 2))
                    : (SteinsAlgorithm(firstNumber / 2, secondNumber));
            }
            else
            {
                return (secondNumber % 2 == 0)
                    ? (SteinsAlgorithm(firstNumber, secondNumber / 2))
                    : (SteinsAlgorithm(secondNumber, Math.Abs(firstNumber - secondNumber)));
            }
        }

        #endregion SteinsAlgorithm

        #region GeneralMethods

        /// <summary>
        /// The private method calculates GCD.
        /// </summary>
        /// <param name="timeCalculationGCD">It's an output parameter and contains the execution time of the algorithm.</param>
        /// <param name="algorithmCalculationGCD">The delegate, which stores the algorithm method.</param>
        /// <param name="numbers">An array of parameters that contains numbers for finding the GCD.</param>
        /// <exception cref="ArgumentException">If the array of parameters is empty or contains only one element.</exception>
        /// <returns>GCD.</returns>
        private static int Calculation(out long timeCalculationGCD, AlgorithmCalculationGCD algorithmCalculationGCD, int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("The array of parameters is empty or contains only one element.");
            }

            TakeAbsNumbers(numbers);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int GCD = Calculation(numbers, algorithmCalculationGCD);
            stopwatch.Stop();

            timeCalculationGCD = stopwatch.ElapsedMilliseconds;

            return GCD;
        }

        /// <summary>
        /// The method calculates the absolute value of all numbers.
        /// </summary>
        /// <param name="numbers">An array of parameters that contains numbers for finding the GCD.</param> 
        private static void TakeAbsNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);
            }
        }

        /// <summary>
        /// The private method calculates GCD.
        /// </summary>
        /// <param name="numbers">An array of parameters that contains numbers for finding the GCD.</param> 
        /// <param name="algorithmCalculationGCD">The delegate, which stores the algorithm method.</param>
        /// <returns>GCD.</returns>
        private static int Calculation(int[] numbers, AlgorithmCalculationGCD algorithmCalculationGCD)
        {
            int[] GCDs = new int[numbers.Length - 1];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                GCDs[i] = algorithmCalculationGCD(numbers[i], numbers[i + 1]);
            }

            return GCDs.Min();
        }

        #endregion GeneralMethods
    }
}
