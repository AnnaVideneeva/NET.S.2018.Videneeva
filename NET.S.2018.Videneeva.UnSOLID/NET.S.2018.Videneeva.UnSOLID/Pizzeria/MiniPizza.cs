using System;

namespace Pizzeria
{
    public class MiniPizza : Pizza
    {
        public override void Cook()
        {
            if (Title.Equals("Pepperoni pizza"))
            {
                Console.Write($"Pizza {Title} not started to prepare.");
            }
            else
            {
                Console.Write($"Pizza {Title} started to prepare.");
            }
        }
    }
}
