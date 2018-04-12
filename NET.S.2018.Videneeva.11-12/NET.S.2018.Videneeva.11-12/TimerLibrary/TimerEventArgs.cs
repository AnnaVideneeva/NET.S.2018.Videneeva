using System;

namespace TimerLibrary
{
    /// <summary>
    /// Provides data for events.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        #region Fields

        private string _message;
        private DateTime _date;
        private int _timeMilliseconds;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Full constructor to initialize the object.
        /// </summary>
        /// <param name="message">A message about the event.</param>
        /// <param name="date">A date the event.</param>
        /// <param name="timeMilliseconds">Number of milliseconds.</param>
        public TimerEventArgs(string message, DateTime date, int timeMilliseconds)
        {
            this.Message = message;
            this.Date = date;
            this.TimeMilliseconds = timeMilliseconds;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// A message about the event.
        /// </summary>
        public string Message
        {
            get => this._message;

            set
            {
                if (object.ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._message = value;
            }
        }

        /// <summary>
        /// A date the event.
        /// </summary>
        public DateTime Date
        {
            get => this._date;

            set
            {
                if (object.ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._date = value;
            }
        }

        /// <summary>
        /// Number of milliseconds
        /// </summary>
        public int TimeMilliseconds
        {
            get => this._timeMilliseconds;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The time is not be negative.", nameof(value));
                }

                this._timeMilliseconds = value;
            }
        }
  
        #endregion Properties
    }
}