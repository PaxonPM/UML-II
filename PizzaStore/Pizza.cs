using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PizzaStore
{
    internal class Pizza
    {
        public int Number { get; }
        public string Name { get; }
        public string Description { get; }
        public int Price { get; }

        public Pizza(int number, string name, string description, int price)
        {
            Number = number;
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Number} {Name} - {Price}kr\n{Description}\n";
        }

    }
}
