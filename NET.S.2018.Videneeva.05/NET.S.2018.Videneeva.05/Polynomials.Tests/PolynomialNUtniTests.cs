using NUnit.Framework;

namespace Polynomials.Tests
{
    [TestFixture]
    public class PolynomialNUnitTests
    {
        [TestCase(new double[] { 3.12, 78.94, 9 }, new double[] { 1.56, 0, 8.9, 78 }, ExpectedResult = new double[] { 4.68, 78.94, 17.9, 78 })]
        [TestCase(new double[] { 2, 7.9, 3, 0, 0 }, new double[] { 34, 20, 78.89, 5 }, ExpectedResult = new double[] { 36, 27.9, 81.89, 5, 0 })]
        [TestCase(new double[] { 0, 4, 9, 8.9 }, new double[] { 1.56 }, ExpectedResult = new double[] { 1.56, 4, 9, 8.9 })]
        [TestCase(new double[] { 0 }, new double[] { 1.56, 7, 9, 3 }, ExpectedResult = new double[] { 1.56, 7, 9, 3 })]
        [TestCase(new double[] { 0, 4, 9, 8.9 }, new double[] { 2.56, 4, 8, 3 }, ExpectedResult = new double[] { 2.56, 8, 17, 11.9 })]
        public double[] OperatorPlus_SuccessfulExecution(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            Polynomial resultPolynomial = firstPolynomial + secondPolynomial;

            return resultPolynomial.Coefficients;
        }

        [TestCase(new double[] { 67, 94, 9, 77 }, new double[] { 8, 94, 8, 78 }, ExpectedResult = new double[] { 59, 0, 1, -1 })]
        [TestCase(new double[] { 56, 0, 9, 7 }, new double[] { 8, 4, 8, 7, 2 }, ExpectedResult = new double[] { 48, -4, 1, 0, -2 })]
        [TestCase(new double[] { 17, 4, 9, 7 }, new double[] { 8, 94 }, ExpectedResult = new double[] { 9, -90, 9, 7 })]

        public double[] OperatorMinus_SuccessfulExecution(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            Polynomial resultPolynomial = firstPolynomial - secondPolynomial;

            return resultPolynomial.Coefficients;
        }

        [TestCase(new double[] { 0, 4, 9, 8 }, 2, ExpectedResult = new double[] { 0, 8, 18, 16 })]
        [TestCase(new double[] { 4, 3, 2, 1, 3, 7.0 }, 1, ExpectedResult = new double[] { 4, 3, 2, 1, 3, 7.0 })]
        [TestCase(new double[] { 7, 8 }, 10, ExpectedResult = new double[] { 70, 80 })]
        public double[] OperatorMultiplyByFactor_SuccessfulExecution(double[] array, double factor)
        {
            Polynomial polynomial = new Polynomial(array);
            Polynomial resultPolynomial = factor * polynomial;

            return resultPolynomial.Coefficients;
        }

        [TestCase(new double[] { 0, 4, 9, 8 }, 2, ExpectedResult = new double[] { 0, 2, 4.5, 4 })]
        [TestCase(new double[] { 4, 3, 2, 1, 3, 7.0 }, 1, ExpectedResult = new double[] { 4, 3, 2, 1, 3, 7.0 })]
        [TestCase(new double[] { 7, 8 }, 10, ExpectedResult = new double[] { 0.7, 0.8 })]
        public double[] OperatorDividsByFactor_SuccessfulExecution(double[] array, double factor)
        {
            Polynomial polynomial = new Polynomial(array);
            Polynomial resultPolynomial = polynomial / factor;

            return resultPolynomial.Coefficients;
        }

        [TestCase(new double[] { 71, 44, 33, 77, 55 }, ExpectedResult = true)]
        [TestCase(new double[] { 11, 22, 33, 44, 55 }, ExpectedResult = true)]
        public static bool OperatorEquals_SuccessfulExecution(double[] array)
        {
            Polynomial firstPolynomial = new Polynomial(array);
            Polynomial secondPolynomial = new Polynomial(array);
            return firstPolynomial == secondPolynomial;
        }

        [TestCase(new double[] { 55, 44, 33, 22, 11 }, new double[] { 66, 77, 88, 99, 555 }, ExpectedResult = true)]
        [TestCase(new double[] { 55, 44, 33, 22, 11 }, new double[] { 55, 44, 33, 22, 11 }, ExpectedResult = false)]
        public static bool OperatorNotEquals_SuccessfulExecution(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            return firstPolynomial != secondPolynomial;
        }

        [TestCase(new double[] { 55, 44, 33, 22, 11 }, new double[] { 66, 77, 88, 99 }, ExpectedResult = true)]
        [TestCase(new double[] { 55, 44, 33, 22, 11 }, new double[] { 66, 77, 88, 99, 555 }, ExpectedResult = false)]
        public static bool OperatorMore_SuccessfulExecution(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            return firstPolynomial > secondPolynomial;
        }

        [TestCase(new double[] { 55, 44 }, new double[] { 66, 77, 88, 99 }, ExpectedResult = true)]
        [TestCase(new double[] { 55, 44, 33, 22, 11 }, new double[] { 66, 77, 88, 99, 555 }, ExpectedResult = false)]
        public static bool OperatorLess_SuccessfulExecution(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            return firstPolynomial < secondPolynomial;
        }

        [TestCase(new double[] { 7, 9 }, ExpectedResult = "7 + 9*x^1")]
        [TestCase(new double[] { 0, 0, 0, 0, 0, 0, 8 }, ExpectedResult = "8*x^6")]
        [TestCase(new double[] { 6, 0, 0, 0, 8 }, ExpectedResult = "6 + 8*x^4")]
        [TestCase(new double[] { 0, 0, 2, 9, 0 }, ExpectedResult = "2*x^2 + 9*x^3")]
        public static string ToString(double[] array)
        {
            Polynomial polynomial = new Polynomial(array);
            return polynomial.ToString();
        }
    }
}

