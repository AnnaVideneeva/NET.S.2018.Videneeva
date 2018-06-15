using System;

namespace Task3.Solution
{
    public class Stock
    {
        public delegate void StockEventHandler(object sender, StockEventArgs e);

        public event StockEventHandler StockEvent;

        public void Market()
        {
            var rnd = new Random();
            int USD = rnd.Next(20, 40);
            int Euro = rnd.Next(30, 50);
            OnEvent(this, new StockEventArgs(USD, Euro));
        }

        protected virtual void OnEvent(object sender, StockEventArgs arg)
        {
            StockEvent?.Invoke(this, arg);
        }
    }
}