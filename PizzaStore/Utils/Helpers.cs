using PizzaStore.Customers;
using PizzaStore.Pizzas;

namespace PizzaStore.Utils
{
    static class Helpers
    {
        public static void message(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintCustomer(Customer customer, string message = "")
        {
            string combinedMessage = $"{message} \n{customer}";
                              
            Console.WriteLine(combinedMessage);
        }

        public static void PrintAllCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine(c));
            
        }

        public static void PrintPizza(Pizza pizza, string message = "")
        {
            string combinedMessage = $"{message} \n{pizza}";
            Console.WriteLine(combinedMessage);
        }

        public static void PrintAllPizzas(Dictionary<string, Pizza> pizzas)
        {
            foreach (var pizza in pizzas.Values)
            {
                Console.WriteLine(pizza);
            }
        }

       
    }
}
