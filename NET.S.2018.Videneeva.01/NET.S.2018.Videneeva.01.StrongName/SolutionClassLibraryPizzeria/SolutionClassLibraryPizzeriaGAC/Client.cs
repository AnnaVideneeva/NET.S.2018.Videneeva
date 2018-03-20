using System;
using ClassLibraryPizzeriaStrongName;

namespace SolutionClassLibraryPizzeriaGAC
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
