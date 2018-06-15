using System.Linq;
using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [TestCase(1, 1, 10, ExpectedResult = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        public int[] Generator_ForSequence1(int a, int b, int n)
        {
            Generator<int> generator = new Generator<int>();

            return generator.Generate(a, b, n, NextElementByFirstFormula).ToArray();
        }

        [TestCase(1, 2, 10, ExpectedResult = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 })]
        public int[] Generator_ForSequence2(int a, int b, int n)
        {
            Generator<int> generator = new Generator<int>();

            return generator.Generate(a, b, n, NextElementBySecondFormula).ToArray();
        }

        [TestCase(1, 2, 10, ExpectedResult = new double[] { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 })]
        public double[] Generator_ForSequence3(double a, double b, int n)
        {
            Generator<double> generator = new Generator<double>();

            return generator.Generate(a, b, n, NextElementByThirdFormula).ToArray();
        }

        #region Private methods

        public static int NextElementByFirstFormula(int xn, int xn_1)
        {
            return xn + xn_1;
        }

        public static int NextElementBySecondFormula(int xn, int xn_1)
        {
            return 6 * xn - 8 * xn_1;
        }

        public double NextElementByThirdFormula(double xn, double xn_1)
        {
            return xn + (xn_1 / xn);
        }

        #endregion Private methods
    }
}