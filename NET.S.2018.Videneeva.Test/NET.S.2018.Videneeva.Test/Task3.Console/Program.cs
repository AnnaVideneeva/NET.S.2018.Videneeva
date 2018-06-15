using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            Bank bank = new Bank("My Bank");
            Broker broker = new Broker("MyBroker");

            stock.StockEvent += bank.Update;
            stock.StockEvent += broker.Update;

            stock.Market();

        }
    }
}
