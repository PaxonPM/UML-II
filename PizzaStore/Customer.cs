using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Customer
    {
        public static int CustomerID { get; private set; }
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Tlf { get; set; }


       public List<string> AllCustomerOrders { get; set; } = new();

        public Customer()
        {
            CustomerID++;
            //Id = CustomerID;
            AllCustomerOrders = new();
        }

        public override string ToString()
        {
            return $"Customer ID: {Id}\nName: {Name}\nEmail: {Email}\nTlf: {Tlf}\n"; //+
                //$"Orders:\n{string.Join("\n", AllCustomerOrders)}";
        }

    }
}
