using System;
using System.Collections.Generic;

namespace FibonacciNumbersSequence
{
    /// <summary>
    /// Provides a method for generating the Fibonacci sequence.
    /// </summary>
    public class FibonacciNumbers
    {
        /// <summary>
        /// Generate Fibonacci's sequence.
        /// </summary>
        /// <param name="count">The number of sequence numbers.</param>
        /// <exception cref="ArgumentException">Throw when <paramref name="count"/> is negative or 0.</exception>
        /// <returns>The Fibonacci's sequence.</returns>
        public static int[] GetFibonacciSequence(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException(nameof(count), "The number of elements in a sequence can not be negative or 0.");
            }

            List<int> fibonacciSequence = new List<int>();

            int prev = 0;
            int curr = 1;
            int temp;

            fibonacciSequence.Add(curr);

            for (int i = 1; i < count; i++)
            {
                fibonacciSequence.Add(prev + curr);

                temp = curr;
                curr = prev + curr;
                prev = temp;
            }

            return fibonacciSequence.ToArray();
        }
    }
}
