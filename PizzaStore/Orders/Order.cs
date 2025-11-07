
using PizzaStore.Customers;
using PizzaStore.Pizzas;


namespace PizzaStore.Orders
{
    public class Order
    {
        public static int OrderID { get; private set; }
        public int SpecificOrderID { get; }
        public Customer OrderCustomer { get; private set; }
        public List<Pizza> PizzasInOrder { get; set; }


        public Order(Customer customer)
        {
            OrderID++;
            SpecificOrderID = OrderID;
            OrderCustomer = customer;
            PizzasInOrder = new();
        }


        public double CalculateTotalPrice()
        {
            int pizzaPrice = 0;
            foreach (Pizza item in PizzasInOrder)
            {
                pizzaPrice += item.Price;
            }
            return pizzaPrice + 40;
        }
        public Customer CompleteOrder()
        {
            OrderCustomer.AllCustomerOrders.Add(ToString());
            return OrderCustomer;

            //return OrderCustomer;
        }
        public override string ToString()
        {
            return $"--------------------" +
                $"\nOrder ID: {SpecificOrderID}\n" +
                $"Customer: {OrderCustomer.Id} - {OrderCustomer.Name}\n" +
                $"Pizzas:\n----\n{string.Join("\n", PizzasInOrder)}-----\n" +
                $"Delivery fee + tax: 40kr\n" +
                $"Total Order Price: {CalculateTotalPrice()}kr" +
                $"\n---------------------";
        }

    }
}
