using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class ConsoleUI
    {

        // methods for: Start menu - customer or admin
        // customer menu: customer selection, view menu, place order, view past orders
        // admin menu: view menu, add pizza, remove pizza, update pizza, delete pizza

        public void StartMenu()
        {
            string[] lines =
            {
                "Welcome to the Pizza Store!",
                "1. Customer",
                "2. Admin",
                "3. Initiate Store.Start() for assignment",
                "0. Exit",
                
            };
            PrintLinesSlowly(lines);
            Console.Write("Please select an option: ");
        }
        public void OrderMenu()
        {
            string[] lines =
            {
                "Order Menu:",
                "1. View Pizza Menu",
                "2. Place Order",
                "3. View Past Orders",
                "0. Back to Main Menu",
                
            };
            PrintLinesSlowly(lines);
            Console.Write("Please select an option: ");
        }

        public void SubOrderMenu()
        {             string[] lines =
            {
                "Sub Order Menu:",
                "1. View Pizza Menu",
                "2. Add Pizza to Order",
                "3. Remove Pizza from Order",
                "4. Finalize Order",
                "0. Back to Order Menu"
            };
            PrintLinesSlowly(lines);
            Console.Write("Please select an option: ");
        }

        public void CustomerSelectionMenu()
        {
            string[] lines =
            {
                "Customer Selection Menu:",
                "1. Print CustomerFile",
                "2. New Customer",
                "3. Existing Customer",
                "4. Update Customer Information",
                "5. Delete Customer",
                "0. Back to Main Menu"
            };
            PrintLinesSlowly(lines);
            Console.Write("Please select an option: ");
        }
        public void AdminMenu()
        {
            string[] lines =
            {
                "Admin Menu:",
                "1. View Pizza Menu",
                "2. Add Pizza",
                "3. Read Pizza",
                "4. Update Pizza",
                "5. Delete Pizza",
                "0. Back to Main Menu"
            };
            PrintLinesSlowly(lines);
            Console.Write("Please select an option: ");
        }

        public Customer GetCustomerDetailsFromUser()
        {
            Console.Write("Enter Customer Id: ");
            string number = Console.ReadLine() ?? "0";
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Enter Customer Phone Number: ");
            string tlf = Console.ReadLine() ?? "";
            return new Customer
            {
                Id = number,
                Name = name,
                Email = email,
                Tlf = tlf
            };
        }

        public Pizza GetPizzaDetailsFromAdmin()
        {
            Console.Write("Enter Pizza Number: ");
            int number = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter Pizza Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Enter Pizza Description: ");
            string description = Console.ReadLine() ?? "";
            Console.Write("Enter Pizza Price: ");
            int price = int.Parse(Console.ReadLine() ?? "0");
            return new Pizza
            {
                Number = number,
                Name = name,
                Description = description,
                Price = price
            };
        }

        public void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
        private void PrintLinesSlowly(string[] lines, int charDelay = 40, int lineDelay = 300)
        {
            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    Console.Write(ch);
                    System.Threading.Thread.Sleep(charDelay);
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(lineDelay);
            }

        }
        public void Logo()
        {
            Console.WriteLine(@"
        ██████╗ ██╗ ██████╗      ███╗   ███╗ █████╗ ███╗   ███╗███╗   ███╗ █████╗ 
        ██╔══██╗██║██╔════╝      ████╗ ████║██╔══██╗████╗ ████║████╗ ████║██╔══██╗
        ██████╦╝██║██║  ███╗     ██╔████╔██║███████║██╔████╔██║██╔████╔██║███████║
        ██╔══██╗██║██║   ██║     ██║╚██╔╝██║██╔══██║██║╚██╔╝██║██║╚██╔╝██║██╔══██║
        ██████╦╝██║╚██████╔╝     ██║ ╚═╝ ██║██║  ██║██║ ╚═╝ ██║██║ ╚═╝ ██║██║  ██║
        ╚═════╝ ╚═╝ ╚═════╝      ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝

 ██████╗  █████╗ ███████╗████████╗███████╗ ██████╗ ███╗   ██╗ ██████╗ ███╗   ███╗██╗ █████╗ 
██╔════╝ ██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██╔═══██╗████╗  ██║██╔═══██╗████╗ ████║██║██╔══██╗
██║  ███╗███████║███████╗   ██║   ██████╔╝██║   ██║██╔██╗ ██║██║   ██║██╔████╔██║██║███████║
██║   ██║██╔══██║╚════██║   ██║   ██╔══██╗██║   ██║██║╚██╗██║██║   ██║██║╚██╔╝██║██║██╔══██║
╚██████╔╝██║  ██║███████║   ██║   ██║  ██║╚██████╔╝██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝  ╚═╝
");
        }
        
        
    
    
    }
}
