using System;
using Matrices.Types;
using NUnit.Framework;

namespace Matrices.Tests
{
    [TestFixture]
    public class MatrixActionsNUnitTests
    {
        private readonly int[,] expectedMatrixSquareMatricesInt = { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };
        private readonly string[,] expectedMatrixSquareMatricesString = { { "11", "22", "33" }, { "44", "55", "66" }, { "77", "88", "99" } };

        private readonly int[,] expectedMatrixDiagonalMatrixInt = { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } };
        private readonly string[,] expectedMatrixDiagonalMatrixString = { { "11", null, null }, { null, "55", null }, { null, null, "99" } };

        private readonly int[,] expectedMatrixSymmetricMatrixInt = { { 2, 4, 6 }, { 4, 10, 12 }, { 6, 12, 18 } };
        private readonly string[,] expectedMatrixSymmetricMatrixString = { { "11", "22", "33" }, { "22", "55", "66" }, { "33", "66", "99" } };

        [Test]
        public void Add_SquareMatrix_And_SquareMatrix_T_is_Int_SuccessfulExecution()
        {
            MathMatrix<int> firstMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            MathMatrix<int> secondMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });

            MathMatrix<int> resultMatrix = MatrixActions<int>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixSquareMatricesInt[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Add_SquareMatrix_And_SquareMatrix_T_is_String_SuccessfulExecution()
        {
            MathMatrix<string> firstMatrix = new SquareMatrix<string>(new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } });
            MathMatrix<string> secondMatrix = new SquareMatrix<string>(new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } });

            MathMatrix<string> resultMatrix = MatrixActions<string>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixSquareMatricesString[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Add_DiagonalMatrix_And_DiagonalMatrix_T_is_Int_SuccessfulExecution()
        {
            MathMatrix<int> firstMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 9 } });
            MathMatrix<int> secondMatrix = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 9 } });

            MathMatrix<int> resultMatrix = MatrixActions<int>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixDiagonalMatrixInt[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Add_DiagonalMatrix_And_DiagonalMatrix_T_is_String_SuccessfulExecution()
        {
            MathMatrix<string> firstMatrix = new DiagonalMatrix<string>(new string[,] { { "1", null, null }, { null, "5", null }, { null, null, "9" } });
            MathMatrix<string> secondMatrix = new DiagonalMatrix<string>(new string[,] { { "1", null, null }, { null, "5", null }, { null, null, "9" } });

            MathMatrix<string> resultMatrix = MatrixActions<string>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixDiagonalMatrixString[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Add_SymmetricMatrix_And_SymmetricMatrix_T_is_Int_SuccessfulExecution()
        {
            MathMatrix<int> firstMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 5, 6 }, { 3, 6, 9 } });
            MathMatrix<int> secondMatrix = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 5, 6 }, { 3, 6, 9 } });

            MathMatrix<int> resultMatrix = MatrixActions<int>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixSymmetricMatrixInt[i, j], resultMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Add_SymmetricMatrix_And_SymmetricMatrix_T_is_String_SuccessfulExecution()
        {
            MathMatrix<string> firstMatrix = new SymmetricMatrix<string>(new string[,] { { "1", "2", "3" }, { "2", "5", "6" }, { "3", "6", "9" } });
            MathMatrix<string> secondMatrix = new SymmetricMatrix<string>(new string[,] { { "1", "2", "3" }, { "2", "5", "6" }, { "3", "6", "9" } });

            MathMatrix<string> resultMatrix = MatrixActions<string>.Add(firstMatrix, secondMatrix);

            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrixSymmetricMatrixString[i, j], resultMatrix[i, j]);
                }
            }
        }
    }
}