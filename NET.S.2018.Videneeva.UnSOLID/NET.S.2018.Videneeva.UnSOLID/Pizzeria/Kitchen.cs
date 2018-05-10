using System.Collections.Generic;

namespace Pizzeria
{
    public class Kitchen : IPizzeria
    {
        public void MakeMenu(List<Pizza> pizza)
        {
        }

        public void Cook(Pizza pizza)
        {
            pizza.Cook();
        }
    }
}
