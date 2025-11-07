
namespace PizzaStore.Pizzas
{
    public class Pizza
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
