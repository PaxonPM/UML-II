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
        //Order Menu
        case "1":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                Console.Write("Please enter your Customer Id: ");
                string customerId = Console.ReadLine() ?? "";
                Customer? customer = cfile.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                {
                    Console.WriteLine($"\nWelcome back, {customer.Name}!");
                    Order currentOrder = new Order(customer);
                }
                else
                {
                    back = true;
                    break;
                }
                ui.OrderMenu();
                string? case1input = Console.ReadLine();
                switch (case1input)
                {
                    //Place order
                    case "1":
                        while(!back)
                        {
                            Console.WriteLine("\n--------------------------------------------");
                            ui.SubOrderMenu();
                            string? subOrderInput = Console.ReadLine();
                            switch (subOrderInput)
                            {
                                //View Menu
                                case "1":
                                    Console.WriteLine("\n--------------------------------------------");
                                    menu.PrintMenu();
                                    ui.Pause();
                                    break;
                                //Add Pizza to Order
                                case "2":
                                    Console.WriteLine("\n--------------------------------------------");
                                    Console.Write("Enter Pizza Number to add to your order: ");
                                    string? pizzaNumberToAdd = Console.ReadLine() ?? "";
                                    if (menu.Pizzas.ContainsKey(pizzaNumberToAdd))
                                    {
                                        Pizza pizzaToAdd = menu.GetPizzaByNumber(pizzaNumberToAdd);

                                        Console.WriteLine($"\nAdded to order: \n{pizzaToAdd}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pizza not found. Please try again.");
                                    }
                                    ui.Pause();
                                    break;
                                //Remove Pizza from Order
                                case "3":
                                    Console.WriteLine("\n--------------------------------------------");
                                    Console.Write("Enter Pizza Number to remove from your order: ");
                                    string? pizzaNumberToRemove = Console.ReadLine() ?? "";
                                    Pizza? pizzaToRemove = customer.AllCustomerOrders
                                        .Select(order => menu.Pizzas.Values.FirstOrDefault(p => p.ToString() == order))
                                        .FirstOrDefault(p => p != null && p.Number.ToString() == pizzaNumberToRemove);
                                    if (pizzaToRemove != null)
                                    {
                                        customer.AllCustomerOrders.Remove(pizzaToRemove.ToString());
                                        Console.WriteLine($"\nRemoved from order: \n{pizzaToRemove}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pizza not found in your order. Please try again.");
                                    }
                                    ui.Pause();
                                    break;
                                //Finalize Order
                                case "4":
                                    Console.WriteLine("\n--------------------------------------------");
                                    Console.WriteLine("Finalizing your order...");
                                    Console.WriteLine("Your order details:");
                                    foreach (var order in customer.AllCustomerOrders)
                                    {
                                        Console.WriteLine(order);
                                    }
                                    customer.AllCustomerOrders.Clear();
                                    back = true;
                                    ui.Pause();
                                    break;
                                // Back to Order Menu
                                case "0":
                                    back = true;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        break;
                    //View Past Orders
                    case "2":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.WriteLine("Feature under development.");
                        ui.Pause();
                        break;
                    // Back to Main Menu
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            break;

        //CustomerMenu PrintCustomerFile, NewCustomer, ExistingCustomer, UpdateCustomerInformation, DeleteCustomer
        case "2":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.CustomerSelectionMenu();
                string? case1input = Console.ReadLine();
                switch (case1input)
                {
                    // Print CustomerFile
                    case "1":
                        Console.WriteLine("\n--------------------------------------------");
                        cfile.PrintAllCustomers();

                        ui.Pause();
                        break;
                    
                    // New Customer
                    case "2":
                        Console.WriteLine("\n--------------------------------------------");
                        Customer newCustomer = ui.GetCustomerDetailsFromUser();
                        cfile.Create(newCustomer);
                        Console.WriteLine($"\nNew user: \n{newCustomer}");
                        ui.Pause();
                        break;

                    // Existing Customer (with name)
                    case "3":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter your customer Name: ");
                        string customerName = Console.ReadLine() ?? "";
                        cfile.Read(customerName);
                        ui.Pause();
                        break;

                    // Update Customer Information
                    case "4":
                        Console.WriteLine("\n--------------------------------------------");
                            Customer updatedCustomer = ui.GetCustomerDetailsFromUser();
                            cfile.Update(updatedCustomer);
                            Console.WriteLine($"\nUpdated user:\n {updatedCustomer}");
                            ui.Pause();
                            break;

                    // Delete Customer
                    case "5":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter your customer ID to delete: ");
                        string customerIdToDelete = Console.ReadLine() ?? "";
                        cfile.Delete(customerIdToDelete);
                        Console.WriteLine($"\nDeleted customer ID: {customerIdToDelete}");
                        ui.Pause();
                        break;

                    // Back to Main Menu
                    case "0":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            break;

        //AdminMenu PrintMenu, Create, Read, Update, Delete
        case "3":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.AdminMenu();
                string? case2input = Console.ReadLine();
                switch (case2input)
                {
                    //PrinMenu
                    case "1":
                        Console.WriteLine("\n--------------------------------------------");
                        menu.PrintMenu();
                        ui.Pause();
                        break;

                    //Create
                    case "2":
                        Console.WriteLine("\n--------------------------------------------");
                        Pizza pizza = ui.GetPizzaDetailsFromAdmin();
                        menu.Create(pizza);
                        Console.WriteLine($"\nCreated pizza: \n{pizza}");
                        ui.Pause();
                        break;
                    
                    //Read
                    case "3":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter Pizza Number to find: ");
                        string? pizzaNumberToFind = Console.ReadLine() ?? "";
                        menu.Read(pizzaNumberToFind);
                        ui.Pause();
                        break;

                    //Update
                    case "4":
                        Console.WriteLine("\n--------------------------------------------");
                        Pizza updatedPizza = ui.GetPizzaDetailsFromAdmin();
                        menu.Update(updatedPizza);
                        Console.WriteLine($"\nUpdated pizza: {updatedPizza}");
                        ui.Pause();
                        break;

                    //Delete
                    case "5":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter Pizza Number to delete: ");
                        string? pizzaNumberToDelete = Console.ReadLine() ?? "";
                        menu.Delete(pizzaNumberToDelete);
                        Console.WriteLine($"\nDeleted pizza number: {pizzaNumberToDelete}");
                        ui.Pause();
                        break;

                    // Back to Main Menu
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            break;
        
        //Exit
        case "0":
            check = false;
            Console.WriteLine("Exiting the program. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

































