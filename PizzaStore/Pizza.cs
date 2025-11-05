using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PizzaStore
{
    class Pizza
    {
        public int Number { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Number} {Name} - {Price}kr\n{Description}\n";
        }

    }
}
