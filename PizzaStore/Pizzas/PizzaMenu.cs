using System.Text.Json;
using PizzaStore.Interfaces;
using PizzaStore.Utils;
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
                ErrorHandler.PrintError(ex, "Error loading pizzas: ");
                Pizzas = new Dictionary<string, Pizza>();
            }
        }
        public void PrintMenu()
        {
            Helpers.message("---- Pizza Menu ----");

            Helpers.PrintAllPizzas(Pizzas);
            
        }
        public Pizza GetPizzaByNumber(string number)
        {
            return Pizzas[number];
        }
        public void Create(Pizza pizzaObj)
        {
            string key = pizzaObj.Number.ToString();

            if (Pizzas.ContainsKey(key))
                ErrorHandler.PizzaNumberError(key, "A pizza with the following number already exists");

            Pizzas[key] = pizzaObj;

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                ErrorHandler.PrintError(ex, "Error saving pizzas: ");
            }
        }
        public void Read(string key)
        {
            if (!Pizzas.ContainsKey(key))
                ErrorHandler.PizzaNumberError(key, "Pizza with the following number doesn't exist");

            Helpers.PrintPizza(Pizzas[key], "You asked for this pizza:");
        }
        public void Update(Pizza pizzaObj)
        {
            string key = pizzaObj.Number.ToString();

            if (!Pizzas.ContainsKey(key))
                ErrorHandler.PizzaNumberError(key, "Pizza with the following number doesn't exist");

            Pizzas[key] = pizzaObj;

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                ErrorHandler.PrintError(ex, "Error saving pizzas: ");
            }

        }
        public void Delete(string key)
        {
            if (!Pizzas.ContainsKey(key))
                ErrorHandler.PizzaNumberError(key, "Pizza with the following number doesn't exist");
            
            Pizzas.Remove(key);

            try
            {
                string jsonString = JsonSerializer.Serialize(Pizzas);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                ErrorHandler.PrintError(ex, "Error saving pizzas: ");
            }
        }
    }
}

