using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza firstPizza = new Pizza()
            {
                Title = "Carbonara pizza",
                Description = "Carbonara pizza Description",
                Composition = new List<string>(),
                Price = 12.12
            };

            Pizza secondPizza = new MiniPizza()
            {
                Title = "Pepperoni pizza",
                Description = "Pepperoni pizza Description",
                Composition = new List<string>(),
                Price = 14.14
            };

            List<Pizza> menuPizza = new List<Pizza>
            {
                firstPizza,
                secondPizza
            };

            Administration administration = new Administration();
            administration.MakeMenu(menuPizza);

            Kitchen kitchen = new Kitchen();
            kitchen.Cook(firstPizza);
            kitchen.Cook(secondPizza);

            System.Console.ReadKey();
        }
    }
}
