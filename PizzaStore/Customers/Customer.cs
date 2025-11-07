
namespace PizzaStore.Customers
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
            Id = CustomerID;
            AllCustomerOrders = new();
        }


        public override string ToString()
        {
            return $"Customer ID: {Id}\nName: {Name}\nEmail: {Email}\nTlf: {Tlf}\n" +
                $"Orders: Total = {AllCustomerOrders.Count}\n" +
                $"\t----------BEGIN Orders For Customer-------\n" +
                $"{string.Join("\n", AllCustomerOrders)}" +
                $"\n\t--------END Orders For Customer---------\n";
        }

    }
}
