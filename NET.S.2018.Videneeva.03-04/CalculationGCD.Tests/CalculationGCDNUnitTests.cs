using System;
using NUnit.Framework;

namespace CalculationGCD.Tests
{
    [TestFixture]
    public class CalculationGCDNUnitTests
    {
        #region EuclidsAlgorithm

        [TestCase(128, 22, 8, ExpectedResult = 2)]
        [TestCase(12, 56, 124, -888, 980, ExpectedResult = 4)]
        [TestCase(10, -50, 55, 125, ExpectedResult = 5)]
        [TestCase(6, 666, -396, 936, ExpectedResult = 6)]
        [TestCase(999, 81, 279, 918, 387, 567, 189, ExpectedResult = 9)]
        [TestCase(681, -942, 15, 39, 84, 192, ExpectedResult = 3)]
        [TestCase(45, -5, 1, 39, 354, 56, ExpectedResult = 1)]
        public int EuclidsAlgorithm_SuccessfulExecution(params int[] numbers)
        {
            return CalculationGCD.EuclidsAlgorithm(out long timeCalculationGCD, numbers);
        }

        [TestCase()]
        [TestCase(123)]
        public void EuclidsAlgorithm_ArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => CalculationGCD.EuclidsAlgorithm(out long timeCalculationGCD, numbers));
        }

        #endregion EuclidsAlgorithm

        #region SteinsAlgorithm

        [TestCase(128, 22, 8, ExpectedResult = 2)]
        [TestCase(12, 56, 124, -888, 980, ExpectedResult = 4)]
        [TestCase(10, -50, 55, 125, ExpectedResult = 5)]
        [TestCase(6, 666, -396, 936, ExpectedResult = 6)]
        [TestCase(999, 81, 279, 918, 387, 567, 189, ExpectedResult = 9)]
        [TestCase(681, -942, 15, 39, 84, 192, ExpectedResult = 3)]
        [TestCase(45, -5, 1, 39, 354, 56, ExpectedResult = 1)]
        public int SteinsAlgorithm_SuccessfulExecution(params int[] numbers)
        {
            return CalculationGCD.SteinsAlgorithm(out long timeCalculationGCD, numbers);
        }

        [TestCase()]
        [TestCase(123)]
        public void SteinsAlgorithm_ArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => CalculationGCD.SteinsAlgorithm(out long timeCalculationGCD, numbers));
        }

        #endregion SteinsAlgorithm
    }
}
