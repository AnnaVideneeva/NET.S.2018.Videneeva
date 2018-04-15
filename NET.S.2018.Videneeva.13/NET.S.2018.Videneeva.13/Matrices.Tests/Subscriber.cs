using System;
using Matrices.Types;

namespace Matrices.Tests
{
    public class Subscriber
    {
        public string Result { get; private set; }

        public DateTime Date { get; private set; }

        public void Message<T>(object sender, MatrixEventArgs<T> e)
        {
            Result = $"The value of {e.OldElement} in row {e.Row} and column {e.Column} has been changed to a value of {e.NewElement}./nTime of change: {e.Date.ToString()}";
            Date = e.Date;
        }
    }
}