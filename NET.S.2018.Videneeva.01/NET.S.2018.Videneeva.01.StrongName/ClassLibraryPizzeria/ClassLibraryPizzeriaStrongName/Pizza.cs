using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPizzeriaStrongName
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Pizza(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Name, Type);
        }
    }
}
