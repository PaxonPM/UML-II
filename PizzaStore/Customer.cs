using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    internal class Customer
    {
        public static int CustomerID { get; private set; }
        public int SpecificCustomerID { get; private set; }
        public string Name { get; private set; }
        public string Email { get; set; }
        public string Tlf { get; set; }


        public List<string> AllCustomerOrders { get; set; }

        public Customer(string name, string email, string tlf)
        {
            CustomerID++;
            SpecificCustomerID = CustomerID;
            Name = name;
            Email = email;
            Tlf = tlf;
            AllCustomerOrders = new();
        }

        public override string ToString()
        {
            return $"Customer ID: {SpecificCustomerID}\nName: {Name}\nEmail: {Email}\nTlf: {Tlf}\n" +
                $"Orders:\n{string.Join("\n", AllCustomerOrders)}";
        }

    }
}
