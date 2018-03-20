using System;
using ClassLibraryPizzeria;

namespace SolutionClassLibraryPizzeria
{
    class Client
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza("Pepperoni Pizza", "Acute");
            Console.WriteLine(pizza.ToString());
            Console.ReadKey();
        }
    }
}
