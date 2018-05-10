using System.Collections.Generic;

namespace Pizzeria
{
    public class Administration : IPizzeria
    {
        public Menu PizzeriaMenu { get; set; }

        public Administration()
        {
            PizzeriaMenu = new Menu();
        }

        public void MakeMenu(List<Pizza> pizza)
        {
            foreach (var p in pizza)
            {
                PizzeriaMenu.AddPizza(p);
            }
        }

        public void Cook(Pizza pizza)
        {
        }
    }
}
