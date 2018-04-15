using System;
using Matrices.Types;
using NUnit.Framework;

namespace Matrices.Tests
{
    [TestFixture]
    public class SquareMatrixNUnitTests
    {
        #region Constructors tests

        [Test]
        public void Constructor_T_is_Int_SuccessfulExecution()
        {
            SquareMatrix<int> firstMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            SquareMatrix<int> secondMatrix = new SquareMatrix<int>(5);

            Assert.AreEqual(6, firstMatrix[1, 2]);
            Assert.AreEqual(5, secondMatrix.Order);
        }

        [Test]
        public void Constructor_T_is_Char_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix<char>(null));
        }

        [Test]
        public void Constructor_T_is_Double_ArgumentException_NotSquare()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<double>(new double[,] { { 2, 3 }, { 1, 2 }, { 5, 6 } }));
        }

        [TestCase(-1)]
        public void Constructor_T_is_Bool_ArgumentException_OrderIsNegative(int order)
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<bool>(order));
        }

        #endregion Constructors tests

        #region Sets value tests

        [TestCase("0", 0, 0)]
        [TestCase("21", 2, 1)]
        [TestCase("13", 1, 3)]
        [TestCase("33", 3, 3)]
        public void SetValue_T_is_String_SuccessfulExecution(string value, int i, int j)
        {
            SquareMatrix<string> matrix = new SquareMatrix<string>(4);

            matrix[i, j] = value;

            Assert.AreEqual(value, matrix[i, j]);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 2, 1)]
        [TestCase(3, 1, 2)]
        [TestCase(4, 2, 2)]
        public void SetValue_T_is_Int_SuccessfulExecution(int value, int i, int j)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Subscriber subscriber = new Subscriber();
            matrix.ItemModified += subscriber.Message;

            int oldElement = matrix[i, j];
            matrix[i, j] = value;

            Assert.AreEqual(
                subscriber.Result,
                $"The value of {oldElement} in row {i} and column {j} has been changed to a value of {matrix[i, j]}./nTime of change: {subscriber.Date.ToString()}");
        }

        [TestCase(-1, 1)]
        [TestCase(-1, 7)]
        [TestCase(6, 1)]
        public void SetValue_T_is_Char_ArgumentNullException(int i, int j)
        {
            SquareMatrix<char> matrix = new SquareMatrix<char>(new char[,] { { 'a', 'a' }, { 'a', 'a' } });

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[i, j] = 'f');
        }

        #endregion Sets value tests
    }
}
