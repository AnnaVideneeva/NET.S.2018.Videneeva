using System;
using System.Collections.Generic;

namespace Pizzeria
{
    public class Pizza
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Composition { get; set; }

        public double Price { get; set; }

        public virtual void Cook()
        {
            Console.Write($"Pizza {Title} started to prepare.");
        }
    }
}
