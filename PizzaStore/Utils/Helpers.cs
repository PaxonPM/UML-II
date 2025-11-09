using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaStore.Customers;

namespace PizzaStore.Utils
{
    static class Helpers
    {

        public static void PrintCustomer(Customer customer, string contextMessage = "")
        {
            var errorMessage = $"{contextMessage} \n{customer}";
                              
            Console.WriteLine(errorMessage);
        }

        public static void HelperPrintAllCustomers(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
