using System;

namespace Matrices.Types
{
    /// <summary>
    /// Describes the matrix and provides ways to work with it.
    /// </summary>
    /// <typeparam name="T">Data type of the matrix.</typeparam>
    public abstract class MathMatrix<T>
    {
        #region Fields

        private T[,] matrix;
        private int order;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="order"/>.
        /// </summary>
        /// <param name="order">An order of matrix.</param>
        public MathMatrix(int order)
        {
            this.Order = order;
            this.Matrix = new T[this.Order, this.Order];           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="matrix"/>
        /// </summary>
        /// <param name="matrix">A matrix.</param>
        public MathMatrix(T[,] matrix)
        {
            this.Matrix = matrix;
            this.Order = matrix.GetLength(0);
        }

        #endregion Constructors

        #region Delegates

        public delegate void MatrixEventHandler(object sender, MatrixEventArgs<T> e);

        #endregion Delegates

        #region Events

        public event MatrixEventHandler ItemModified;

        #endregion Events  

        #region Properties              

        /// <summary>
        /// Gets or sets the order of matrix.
        /// </summary>
        public int Order
        {
            get => order;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The order of matrix is not be negative.", nameof(value));
                }

                this.order = value;
            }
        }

        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        protected T[,] Matrix
        {
            get => this.matrix;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.matrix = value;
            }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Gets or sets the element of the matrix by the indices.
        /// </summary>
        /// <param name="i">The number of row.</param>
        /// <param name="j">The number of column.</param>
        /// <returns>The element of the matrix by the indices.</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                this.CheckingIndexes(i, j);
                return this.Matrix[i, j];
            }

            set
            {
                this.CheckingIndexes(i, j);

                T oldElement = this.Matrix[i, j];

                this.Matrix[i, j] = value;

                OnItemModified(this, new MatrixEventArgs<T>(DateTime.Now, oldElement, value, i, j));
            }
        }

        #endregion Indexers

        #region Events method

        /// <summary>
        /// Notifies the event of the registered object.
        /// </summary>
        /// <param name="sender">A reference to the class that caused the event.</param>
        /// <param name="e">Data about event.</param>
        protected virtual void OnItemModified(object sender, MatrixEventArgs<T> e)
        {
            ItemModified?.Invoke(sender, e);
        }

        #endregion Events method

        #region Protected methods

        private void CheckingIndexes(int i, int j)
        {
            if (i < 0 || i >= matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j < 0 || j >= matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }
        }

        #endregion Protected methods
    }
}
