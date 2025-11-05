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

            PizzaMenu menu = new PizzaMenu("pizzas.json");

            //Order Order1 = new Order(Peter);
            //Order1.PizzasInOrder.Add(menu.GetPizzaByNumber("1"));

            //Order Order2 = new Order(Tim);
            //Order2.PizzasInOrder.Add(menu.GetPizzaByNumber("2"));

            //Order Order3 = new Order(Kim);
            //Order3.PizzasInOrder.Add(menu.GetPizzaByNumber("3"));


            //Console.WriteLine($"\nAll the objects was created!!");

            //Console.WriteLine($"-------------------------------------------------------------------");
            //Console.WriteLine($"Price for Order 1:\n{Order1.CalculateTotalPrice()}kr\n-------------------------------------");
            //Console.WriteLine($"Print Order 1: \n{Order1.ToString()}");

            //Console.WriteLine($"-------------------------------------------------------------------");
            //Console.WriteLine($"Price for Order 2:\n{Order2.CalculateTotalPrice()}kr\n-------------------------------------");
            //Console.WriteLine($"Print Order 2: \n{Order2.ToString()}");

            //Console.WriteLine($"-------------------------------------------------------------------");
            //Console.WriteLine($"Price for Order 3:\n{Order3.CalculateTotalPrice()}kr\n-------------------------------------");
            //Console.WriteLine($"Print Order 3: \n{Order3.ToString()}");

            //Console.WriteLine($"-------------------------------------------------------------------");
            //Console.WriteLine("1 order with several pizzas for Kim");
            //Order Order4 = new Order(Kim);
            //Order4.PizzasInOrder.Add(menu.GetPizzaByNumber("3"));
            //Order4.PizzasInOrder.Add(menu.GetPizzaByNumber("4"));
            //Order4.CompleteOrder();
            //Order3.CompleteOrder();
            //Console.WriteLine($"Price for Order 4:\n{Order4.CalculateTotalPrice()}kr\n-------------------------------------");
            //Console.WriteLine($"Print Order 4: \n{Order4.ToString()}");
            //Console.WriteLine($"\n\nAnd all the orders made by Kim:\n///////{string.Join("\n", Kim.AllCustomerOrders)}\n//////////");







        }

    }
}
