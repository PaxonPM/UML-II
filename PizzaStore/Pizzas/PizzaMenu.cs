using System.Text.Json;
using PizzaStore.Interfaces;

namespace PizzaStore.Pizzas
{
     public class PizzaMenu : Icrud<string, string, Pizza>
    {
        public string FilePath { get; private set; }
        public Dictionary<string, Pizza> Pizzas { get; private set; } = new Dictionary<string, Pizza>();
        public PizzaMenu(string filePath)
        {
            FilePath = filePath;
            LoadPizzasFromJson(FilePath);
        }

        private void LoadPizzasFromJson(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                Pizzas = JsonSerializer.Deserialize<Dictionary<string, Pizza>>(json) ?? new Dictionary<string, Pizza>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading pizzas: {ex.Message}");
                Pizzas = new Dictionary<string, Pizza>();
            }
        }
        public void PrintMenu()
        {
            Console.WriteLine("---- Pizza Menu ----");
            foreach (Pizza pizza in Pizzas.Values)
            {
                Console.WriteLine(pizza);
            }
        }
        public Pizza GetPizzaByNumber(string number)
        {
            return Pizzas[number];
        }
        public void Create(Pizza pizzaObj)
        {
            string key = pizzaObj.Number.ToString();

            if (Pizzas.ContainsKey(key))
                throw new Exception($"Pizza with number {key} already exists");


            Pizzas[key] = pizzaObj;

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving pizzas: {ex.Message}");
            }
        }
        public void Read(string key)
        {
            if (!Pizzas.ContainsKey(key))
                throw new Exception($"Pizza with number {key} doesn't exists");

            Console.WriteLine($"You asked for this pizza:\n {Pizzas[key]}");
        }
        public void Update(Pizza pizzaObj)
        {
            string key = pizzaObj.Number.ToString();

            if (!Pizzas.ContainsKey(key))
                throw new Exception($"Pizza with number {key} doesn't exists");

            Pizzas[key] = pizzaObj;

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving pizzas: {ex.Message}");
            }

        }
        public void Delete(string key)
        {
            if (!Pizzas.ContainsKey(key))
                throw new Exception($"Pizza with number {key} doesn't exists");
            Pizzas.Remove(key);

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving pizzas: {ex.Message}");
            }
        }
    }
}

