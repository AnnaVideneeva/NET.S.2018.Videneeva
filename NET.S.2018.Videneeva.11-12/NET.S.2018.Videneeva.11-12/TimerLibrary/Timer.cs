using System;
using System.Threading;

namespace TimerLibrary
{
    /// <summary>
    /// Provides methods for work with timer.
    /// </summary>
    public class Timer
    {
        #region Fields

        private int _waitingTime;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Full constructor to initialize the object.
        /// </summary>
        /// <param name="waitingTime">The waiting time.</param>
        public Timer(int waitingTime)
        {
            WaitingTime = waitingTime;
        }

        /// <summary>
        /// The constructor to initialize the object.
        /// </summary>
        public Timer() : this(0)
        {
        }

        #endregion Constructors

        #region Delegates

        public delegate void TimerEventHandler(object sender, TimerEventArgs e);

        #endregion Delegates

        #region Events

        public event TimerEventHandler TimerStarted;

        public event TimerEventHandler TimerExpired;

        #endregion Events    

        #region Properties

        /// <summary>
        /// The waiting time.
        /// </summary>
        public int WaitingTime
        {
            get => _waitingTime;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The waiting time is not be negative.", nameof(value));
                }

                _waitingTime = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Starts counting the time.
        /// </summary>
        public void Start()
        {
            TimeStarted(this, new TimerEventArgs("Time started!", DateTime.Now, WaitingTime));

            Thread.Sleep(WaitingTime);

            TimeExpired(this, new TimerEventArgs("Time is over!", DateTime.Now, WaitingTime));
        }

        #endregion Methods

        #region Events method

        /// <summary>
        /// Notifies the event of the registered object.
        /// </summary>
        /// <param name="sender">A reference to the class that caused the event.</param>
        /// <param name="e">Data about event.</param>
        protected virtual void TimeStarted(object sender, TimerEventArgs e)
        {
            TimerStarted?.Invoke(sender, e);
        }

        /// <summary>
        /// Notifies the event of the registered object.
        /// </summary>
        /// <param name="sender">A reference to the class that caused the event.</param>
        /// <param name="e">Data about event.</param>
        protected virtual void TimeExpired(object sender, TimerEventArgs e)
        {
            TimerExpired?.Invoke(sender, e);
        }

        #endregion Events method
    }
}