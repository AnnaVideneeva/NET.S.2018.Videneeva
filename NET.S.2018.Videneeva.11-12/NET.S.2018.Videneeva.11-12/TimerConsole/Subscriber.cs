using System;
using TimerLibrary;

namespace TimerConsole
{
    /// <summary>
    /// Provides the method of the event handler.
    /// </summary>
    public class Subscriber
    {
        #region Fields

        private Timer _timer;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Full contructor to initialize the object.
        /// </summary>
        /// <param name="timer">The timer.</param>
        public Subscriber(Timer timer)
        {
            Timer = timer;
            Timer.TimerStarted += Message;
            Timer.TimerExpired += Message;
        }

        /// <summary>
        /// Default contructor to initialize the object.
        /// </summary>
        public Subscriber()
        {
            Timer = new Timer();
            Timer.TimerStarted += Message;
            Timer.TimerExpired += Message;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The timer.
        /// </summary>
        public Timer Timer
        {
            get => _timer;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _timer = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Displays data about event.
        /// </summary>
        /// <param name="sender">A reference to the class that caused the event.</param>
        /// <param name="e">Data about event.</param>
        public void Message(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Message: {0}\nDate: {1}\nNumber of milliseconds: {2}", e.Message, e.Date, e.TimeMilliseconds);
        }

        #endregion Methods
    }
}