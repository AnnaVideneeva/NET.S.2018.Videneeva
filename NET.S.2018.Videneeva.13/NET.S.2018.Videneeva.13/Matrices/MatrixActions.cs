using System;
using Matrices.Types;

namespace Matrices
{
    /// <summary>
    /// Provides methods for working with matrices.
    /// </summary>
    /// <typeparam name="T">Data type of the matrix.</typeparam>
    public static class MatrixActions<T>
    {
        /// <summary>
        /// Performs the addition of two matrices.
        /// </summary>
        /// <param name="firstMatrix">The first matrix.</param>
        /// <param name="secondMatrix">The second matrix.</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="firstMatrix"/> 
        /// or <paramref name="secondMatrix"/> is null.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="firstMatrix"/> 
        /// and <paramref name="secondMatrix"/> are not of the same order.</exception>
        /// <returns>Matrix of the sum of two matrices.</returns>
        public static MathMatrix<T> Add(MathMatrix<T> firstMatrix, MathMatrix<T> secondMatrix)
        {
            if (ReferenceEquals(firstMatrix, null))
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }

            if (ReferenceEquals(secondMatrix, null))
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }

            if (firstMatrix.Order != secondMatrix.Order)
            {
                throw new ArgumentException("Matrices must be of the same order.");
            }

            var resultMatrix = new T[firstMatrix.Order, secondMatrix.Order];

            for (int i = 0; i < firstMatrix.Order; i++)
            {
                for (int j = 0; j < secondMatrix.Order; j++)
                {
                    if (object.Equals(firstMatrix[i, j], default(T)))
                    {
                        resultMatrix[i, j] = secondMatrix[i, j];
                    }
                    else if (object.Equals(secondMatrix[i, j], default(T)))
                    {
                        resultMatrix[i, j] = firstMatrix[i, j];
                    }
                    else
                    {
                        resultMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }                
                }
            }

            return new SquareMatrix<T>(resultMatrix);
        }
    }
}
