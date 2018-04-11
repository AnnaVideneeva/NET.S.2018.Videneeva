using System;
using NUnit.Framework;

namespace FibonacciNumbersSequence.Tests
{
    [TestFixture]
    public class FibonacciNumbersNUnitTests
    {
        [TestCase(1, new int[] { 1 })]
        [TestCase(5, new int[] { 1, 1, 2, 3, 5 })]
        [TestCase(10, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(15, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 })]
        [TestCase(20, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 })]
        public void GetFibonacciSequence_SuccessfulExecution(int count, int[] correctFibonacciSequence)
        {
            CollectionAssert.AreEqual(FibonacciNumbers.GetFibonacciSequence(count), correctFibonacciSequence);
        }

        [TestCase(-5)]
        [TestCase(0)]
        public void GetFibonacciSequence_ArgumentException(int count)
        {
            Assert.Throws<ArgumentException>(() => FibonacciNumbers.GetFibonacciSequence(count));
        }
    }
}
