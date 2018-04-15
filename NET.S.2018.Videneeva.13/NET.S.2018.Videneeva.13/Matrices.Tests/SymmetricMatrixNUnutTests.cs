using System;
using Matrices.Types;
using NUnit.Framework;

namespace Matrices.Tests
{
    [TestFixture]
    public class SymmetricMatrixNUnutTests
    {
        #region Constructors tests

        [Test]
        public void Constructor_T_is_Int_SuccessfulExecution()
        {
            SymmetricMatrix<int> firstMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } });
            SymmetricMatrix<int> secondMatrix = new SymmetricMatrix<int>(5);

            Assert.AreEqual(4, firstMatrix[1, 2]);
            Assert.AreEqual(5, secondMatrix.Order);
        }

        [Test]
        public void Constructor_T_is_Char_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SymmetricMatrix<char>(null));
        }

        [Test]
        public void Constructor_T_is_Double_ArgumentException_NotSymmetric()
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<double>(new double[,] { { 2, 3 }, { 1, 2 } }));
        }

        [TestCase(-1)]
        public void Constructor_T_is_Bool_ArgumentException_OrderIsNegative(int order)
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<bool>(order));
        }

        #endregion Constructors tests

        #region Sets value tests

        [TestCase("5", 0, 0)]
        [TestCase("0", 2, 1)]
        [TestCase("4", 1, 1)]
        [TestCase("3", 3, 3)]
        public void SetValue_T_is_String_SuccessfulExecution(string value, int i, int j)
        {
            SymmetricMatrix<string> matrix = new SymmetricMatrix<string>(4);

            matrix[i, j] = value;

            Assert.AreEqual(value, matrix[i, j]);
            Assert.AreEqual(value, matrix[j, i]);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 2, 2)]
        [TestCase(3, 2, 2)]
        [TestCase(4, 2, 2)]
        public void SetValue_T_is_Int_SuccessfulExecution(int value, int i, int j)
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } });
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
            SymmetricMatrix<char> matrix = new SymmetricMatrix<char>(new char[,] { { 'a', 'a' }, { 'a', 'a' } });

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[i, j] = 'f');
        }

        #endregion Sets value tests
    }
}