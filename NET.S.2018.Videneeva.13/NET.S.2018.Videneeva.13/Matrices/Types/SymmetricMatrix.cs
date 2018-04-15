using System;

namespace Matrices.Types
{
    /// <summary>
    /// Describes the symmetric matrix and provides ways to work with it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="matrix"/>
        /// </summary>
        /// <param name="matrix">A matrix.</param>
        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            if (!this.IsSymmetricMatrix(matrix))
            {
                throw new ArgumentException("This matrix is not symmetric.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="order"/>.
        /// </summary>
        /// <param name="order">An order of matrix.</param>
        public SymmetricMatrix(int order) : base(order)
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
                if (i == j)
                {
                    base[i, j] = value;
                }
                else
                {
                    base[i, j] = value;
                    base[j, i] = value;
                }
            }
        }

        #endregion Overriding methods

        #region Private tests

        private bool IsSymmetricMatrix(T[,] matrix)
        {
            for (int i = 0; i < this.Order; i++)
            {
                for (int j = 0; j < this.Order; j++)
                {
                    if (!object.Equals(this.Matrix[i, j], this.Matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion Private tests
    }
}