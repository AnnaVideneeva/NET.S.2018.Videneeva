using System;

namespace Matrices.Types
{
    /// <summary>
    /// Describes the square matrix and provides ways to work with it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : MathMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="matrix"/>
        /// </summary>
        /// <param name="matrix">A matrix.</param>
        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            if (!this.IsSquareMatrix(matrix))
            {
                throw new ArgumentException("This matrix is not square.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="order"/>.
        /// </summary>
        /// <param name="order">An order of matrix.</param>
        public SquareMatrix(int order) : base(order)
        {
        }

        #endregion Constructors

        #region Overriding methods

        /// <summary>
        /// Gets or sets the element of the matrix by the indices.
        /// </summary>
        /// <param name="i">The number of row.</param>
        /// <param name="j">The number of column.</param>
        /// <returns>The element of the matrix by the indices.</returns>
        public override T this[int i, int j]
        {
            get
            {
                return base[i, j];
            }

            set
            {
                base[i, j] = value;
            }
        }

        #endregion Overriding methods

        #region Private tests

        private bool IsSquareMatrix(T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1)
                ? true
                : false;
        }

        #endregion Private tests
    }
}