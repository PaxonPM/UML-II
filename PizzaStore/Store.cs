using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    internal class Store
    {


        public void Start()
        {
            Console.WriteLine($"Creating the 3 Pizza Objects");
            Pizza Margherita = new Pizza(1, "- Margherita", "Tomato, Cheese", 85);
            Pizza Vesuvio = new Pizza(2, "Vesuvio", "- tomato, Cheese, Ham", 97);
            Pizza Capri = new Pizza(3, "Capricciosa", "- Tomato, cheese, ham, mushrooms", 99);
            //Pizza Calzone = new Pizza(4, "Calzone", "Baked Pizza, Tomata, Cheese, Ham, Mushroom", 99);

            Console.WriteLine($"Creating the 3 Customer Objects");
            Customer Peter = new Customer("Peter", "peter@gmail.com", "44332211");
            Customer Tim = new Customer("Tim", "Tim@gmail.com", "88776655");
            Customer Kim = new Customer("Kim", "Kim@gmail.com", "11223344");

            Console.WriteLine($"Creating the 3 Order Objects and adding a pizza object for each order");
            Order Order1 = new Order(Peter);
            Order1.PizzasInOrder.Add(Margherita);

            Order Order2 = new Order(Tim);
            Order2.PizzasInOrder.Add(Vesuvio);

            Order Order3 = new Order(Kim);
            Order3.PizzasInOrder.Add(Capri);


            Console.WriteLine($"\nAll the objects was created!!");

            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine($"Price for Order 1:\n{Order1.CalculateTotalPrice()}kr\n-------------------------------------");
            Console.WriteLine($"Print Order 1: \n{Order1.ToString()}");

            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine($"Price for Order 2:\n{Order2.CalculateTotalPrice()}kr\n-------------------------------------");
            Console.WriteLine($"Print Order 2: \n{Order2.ToString()}");

            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine($"Price for Order 3:\n{Order3.CalculateTotalPrice()}kr\n-------------------------------------");
            Console.WriteLine($"Print Order 3: \n{Order3.ToString()}");

            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine("1 order with several pizzas for Kim");
            Order Order4 = new Order(Kim);
            Order4.PizzasInOrder.Add(Vesuvio);
            Order4.PizzasInOrder.Add(Capri);
            Order4.CompleteOrder();
            Order3.CompleteOrder();
            Console.WriteLine($"Price for Order 4:\n{Order4.CalculateTotalPrice()}kr\n-------------------------------------");
            Console.WriteLine($"Print Order 4: \n{Order4.ToString()}");
            Console.WriteLine($"\n\nAnd all the orders made by Kim:\n///////{string.Join("\n", Kim.AllCustomerOrders)}\n//////////");







        }

    }
}
