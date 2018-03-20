using System;
using Pizzeria;

class Client
{
        static void Main()
        {
            Pizza pizza = new Pizza();
            pizza.PizzaInfo();

            PepperoniPizza pepperoni = new PepperoniPizza();
            pepperoni.PepperoniPizzaInfo();

            DoublePepperoniPizza doublePepperoni = new DoublePepperoniPizza();
            doublePepperoni.DoublePepperoniPizzaInfo();

            Console.ReadLine();
        }
    }

