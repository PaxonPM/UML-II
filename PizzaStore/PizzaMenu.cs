using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace PizzaStore
{
     class PizzaMenu : Icrud<Pizza, string>
    {
        public Dictionary<string, Pizza> Pizzas { get; private set; } = new Dictionary<string, Pizza>();
        public PizzaMenu(string filePath)
        {
            LoadPizzasFromJson(filePath);
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
            foreach (var pizza in Pizzas.Values)
            {
                Console.WriteLine(pizza);
            }
        }

        public Pizza GetPizzaByNumber(string number)
        {
            return Pizzas[number];
        }

        public override void Create(Pi)
        {

        }
        public void Read()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}

