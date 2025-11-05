// See https://aka.ms/new-console-template for more information


using PizzaStore;

bool check = true;

ConsoleUI ui = new ConsoleUI();
PizzaMenu menu = new PizzaMenu("pizzas.json");
CustomerFile cfile = new CustomerFile("customers.json");


while (check)
{
    bool back = false;
    Console.Clear();
    ui.Logo();
    ui.StartMenu();
    string? input = Console.ReadLine();
    switch (input)
    {
        case "1":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.CustomerSelectionMenu();
                string? case1input = Console.ReadLine();
                switch (case1input)
                {
                    case "1":
                        // Print CustomerFile
                        Console.WriteLine("\n--------------------------------------------");
                        cfile.PrintAllCustomers();

                        ui.Pause();
                        break;

                    case "2":
                        // New Customer
                        Console.WriteLine("\n--------------------------------------------");
                        Customer newCustomer = ui.GetCustomerDetailsFromUser();
                        cfile.Create(newCustomer);
                        Console.WriteLine($"\nNew user: \n{newCustomer}");
                        ui.Pause();
                        break;

                    case "3":
                        // Existing Customer
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter your customer ID: ");
                        string? customerId = Console.ReadLine();
                        if (int.TryParse(customerId, out int id))
                        {
                            customerId = id.ToString();
                            cfile.Read(id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid customer ID format.");
                        }
                        ui.Pause();
                        break;

                    case "4":
                        // Update Customer Information
                        Console.WriteLine("\n--------------------------------------------");
                            Customer updatedCustomer = ui.GetCustomerDetailsFromUser();
                            cfile.Update(updatedCustomer);
                            Console.WriteLine($"\nUpdated user:\n {updatedCustomer}");
                            ui.Pause();
                            break;

                    case "5":
                        // Delete Customer
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter your customer ID to delete: ");
                        string? customerIdToDelete = Console.ReadLine();
                        if (int.TryParse(customerIdToDelete, out int deleteId))
                        {
                            cfile.Delete(deleteId);
                            Console.WriteLine($"\nDeleted customer ID: {deleteId}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid customer ID format.");
                        }
                        ui.Pause();
                        break;

                    case "0":
                        // Back to Main Menu
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            break;
        case "2":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.AdminMenu();
                string? case2input = Console.ReadLine();
                switch (case2input)
                {
                    case "1":
                        Console.WriteLine("\n--------------------------------------------");
                        menu.PrintMenu();
                        ui.Pause();
                        break;
                    case "2":
                        Console.WriteLine("\n--------------------------------------------");
                        Pizza pizza = ui.GetPizzaDetailsFromAdmin();
                        menu.Create(pizza);
                        Console.WriteLine($"\nCreated pizza: \n{pizza}");
                        ui.Pause();
                        break;
                    case "3":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter Pizza Number to delete: ");
                        string? pizzaNumberToDelete = Console.ReadLine() ?? "";
                        menu.Delete(pizzaNumberToDelete);
                        Console.WriteLine($"\nDeleted pizza number: {pizzaNumberToDelete}");
                        ui.Pause();
                        break;
                    case "4":
                        Console.WriteLine("\n--------------------------------------------");
                        Pizza updatedPizza = ui.GetPizzaDetailsFromAdmin();
                        menu.Update(updatedPizza);
                        Console.WriteLine($"\nUpdated pizza: {updatedPizza}");
                        ui.Pause();
                        break;
                    case "0":
                        back = true;
                        // Back to Main Menu
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            break;
        case "0":
            check = false;
            Console.WriteLine("Exiting the program. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

































