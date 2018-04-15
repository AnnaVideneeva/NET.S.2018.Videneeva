using System;
using Matrices.Types;
using NUnit.Framework;

namespace Matrices.Tests
{
    [TestFixture]
    public class DiagonalMatrixNUnutTests
    {
        #region Constructors tests

        [Test]
        public void Constructor_T_is_Int_SuccessfulExecution()
        {
            DiagonalMatrix<int> firstMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } });
            DiagonalMatrix<int> secondMatrix = new DiagonalMatrix<int>(5);

            Assert.AreEqual(0, firstMatrix[1, 2]);
            Assert.AreEqual(5, secondMatrix.Order);
        }

        [Test]
        public void Constructor_T_is_Char_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiagonalMatrix<char>(null));
        }

        [Test]
        public void Constructor_T_is_Double_ArgumentException_NotDiagonal()
        {
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<double>(new double[,] { { 2, 3 }, { 1, 2 } }));
        }

        [TestCase(-1)]
        public void Constructor_T_is_Bool_ArgumentException_OrderIsNegative(int order)
        {
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<bool>(order));
        }

        #endregion Constructors tests

        #region Sets value tests

        [TestCase("5", 0, 0)]
        [TestCase(null, 1, 2)]
        [TestCase("4", 1, 1)]
        [TestCase("3", 3, 3)]
        public void SetValue_T_is_String_SuccessfulExecution(string value, int i, int j)
        {
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(4);

            matrix[i, j] = value;

            Assert.AreEqual(value, matrix[i, j]);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 1, 1)]
        [TestCase(3, 2, 2)]
        public void SetValue_T_is_Int_SuccessfulExecution(int value, int i, int j)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } });
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
        public void SetValue_T_is_Char_ArgumentOutOfRangeException(int i, int j)
        {
            DiagonalMatrix<char> matrix = new DiagonalMatrix<char>(new char[,] { { 'a', '\0' }, { '\0', 'a' } });

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[i, j] = '\0');
        }

        [TestCase(1, 2)]
        [TestCase(3, 6)]
        [TestCase(6, 1)]
        public void SetValue_T_is_Char_ArgumentException(int i, int j)
        {
            DiagonalMatrix<char> matrix = new DiagonalMatrix<char>(7);

            Assert.Throws<ArgumentException>(() => matrix[i, j] = 'f');
        }

        #endregion Sets value tests
    }
}
