namespace Task3.Solution
{
    public class StockEventArgs
    {
        public int USD { get; set; }
        public int Euro { get; set; }

        public StockEventArgs(int USD, int Euro)
        {
            this.USD = USD;
            this.Euro = Euro;
        }
    }
}