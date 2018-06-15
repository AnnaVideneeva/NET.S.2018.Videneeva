using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task4.Solution.Interface;
using Task4.Solution.Services;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            Task4.Solution.Calculator calculator = new Task4.Solution.Calculator();
            IAlgorithmCalculateAverage algorithm = new AlgorithmCalculateAverageByMean();

            double expected = 8.3636363;

            double actual = calculator.CalculateAverage(values, algorithm);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            Task4.Solution.Calculator calculator = new Task4.Solution.Calculator();
            IAlgorithmCalculateAverage algorithm = new AlgorithmCalculateAverageByMedian();

            double expected = 8.0;

            double actual = calculator.CalculateAverage(values, algorithm);

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}