using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    public class Menu
    {
        public void AddPizza(Pizza pizza)
        {
            FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "MenuPizzeria.txt", FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(pizza.Title);
            writer.Write(pizza.Description);

            foreach(var p in pizza.Composition)
            {
                writer.Write(p);
            }

            writer.Write(pizza.Price);

            writer.Close();
            file.Close();
        }
    }
}
