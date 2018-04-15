using System;

namespace Matrices.Types
{
    /// <summary>
    /// Provides data for events.
    /// </summary>
    /// <typeparam name="T">Data type of the matrix.</typeparam>
    public class MatrixEventArgs<T> : EventArgs
    {
        #region Fields

        private DateTime date;
        private T oldElement;
        private T newElement;
        private int row;
        private int column;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Full constructor fo nitializes a new instance.
        /// </summary>
        /// <param name="date">Time of change of the matrix element.</param>
        /// <param name="oldElement">The old element.</param>
        /// <param name="newElement">The new element.</param>
        /// <param name="row">The row in which the element is located.</param>
        /// <param name="column">The column in which the element is located.</param>
        public MatrixEventArgs(DateTime date, T oldElement, T newElement, int row, int column)
        {
            this.Date = date;
            this.OldElement = oldElement;
            this.NewElement = newElement;
            this.Row = row;
            this.Column = column;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Sets and gets the time of change of the matrix element. 
        /// </summary>
        public DateTime Date
        {
            get => this.date;

            set
            {
                if (object.ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.date = value;
            }
        }

        /// <summary>
        /// Sets and gets the old element.
        /// </summary>
        public T OldElement
        {
            get => this.oldElement;

            set
            {
                this.oldElement = value;
            }
        }

        /// <summary>
        /// Sets and gets the new element.
        /// </summary>
        public T NewElement
        {
            get => this.newElement;

            set
            {
                this.newElement = value;
            }
        }

        /// <summary>
        /// Sets and gets the row in which the element is located.
        /// </summary>
        public int Row
        {
            get => this.row;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"The value {value} is not be negative.", nameof(value));
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Sets and gets the column in which the element is located.
        /// </summary>
        public int Column
        {
            get => this.column;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"The value {value} is not be negative.", nameof(value));
                }

                this.column = value;
            }
        }

        #endregion Properties
    }
}