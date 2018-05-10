using System.Collections.Generic;

namespace Pizzeria
{
    public interface IPizzeria
    {
        void MakeMenu(List<Pizza> pizza);
        void Cook(Pizza pizza);
    }
}
