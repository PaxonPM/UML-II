using PizzaStore;
using PizzaStore.Customers;
using PizzaStore.Orders;
using PizzaStore.Pizzas;
using PizzaStore.UI;

bool check = true;

ConsoleUI ui = new ConsoleUI();
PizzaMenu menu = new PizzaMenu("Data/pizzas.json");
CustomerFile cfile = new CustomerFile("Data/customers.json");
Store store = new Store();

while (check)
{
    bool back = false;
    
    ui.Logo();
    ui.StartMenu();
    string? input = Console.ReadLine();
    switch (input)
    {
        //Order Menu - Place Order(SubOrderMenu), View Past Orders
        case "1":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                Console.Write("Please enter your Customer Id: ");
                int customerId = int.Parse(Console.ReadLine() ?? "0");
                Customer? customer = cfile.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                {
                    Console.WriteLine($"\nWelcome back, {customer.Name}!");
                    Order currentOrder = new Order(customer);
                    ui.OrderMenu();
                    string? case1input = Console.ReadLine();
                    switch (case1input)
                    {
                        //Place order
                        case "1":
                            while (!back)
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
                                            currentOrder.PizzasInOrder.Add(pizzaToAdd);
                                            Console.WriteLine($"\nAdded to order: \n{pizzaToAdd}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pizza not found. Please try again.");
                                        }
                                        ui.Pause();
                                        break;
                                    //Show Current Order
                                    case "3":
                                        Console.WriteLine(currentOrder.ToString());
                                        ui.Pause();
                                        break;
                                    //Remove Pizza from Order
                                    case "4":
                                        Console.WriteLine("\n--------------------------------------------");
                                        Console.Write("Enter Pizza Number to remove from your order: ");
                                        int? pizzaNumber = int.Parse(Console.ReadLine() ?? "0");
                                        Pizza? pizzaToRemove = currentOrder.PizzasInOrder.FirstOrDefault(p => p.Number == pizzaNumber);
                                        if (pizzaToRemove != null)
                                        {
                                            currentOrder.PizzasInOrder.Remove(pizzaToRemove);
                                            Console.WriteLine($"\nRemoved pizza number: {pizzaNumber}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pizza not found in your order.");
                                        }
                                        ui.Pause();
                                        break;
                                    //Finalize Order
                                    case "5":
                                        Console.WriteLine("\n--------------------------------------------");
                                        Console.WriteLine("Finalizing your order...");
                                        Console.WriteLine("Your order details:");
                                        Console.WriteLine(currentOrder.ToString()); 
                                        Customer saveCustomer = currentOrder.CompleteOrder();
                                        cfile.Update(saveCustomer);
                                        back = true;
                                        ui.Pause();
                                        break;
                                    // Back to Order Menu
                                    case "0":
                                        back = true;
                                        Console.Clear();
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
                            Console.WriteLine(customer.ToString());
                            ui.Pause();
                            break;
                        // Back to Main Menu
                        case "0":
                            back = true;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found. Returning to main menu.");
                    back = true;
                    break;
                }
                
            }
            break;

        //CustomerMenu - PrintCustomerFile, New Customer, read Customer, Update Customer, Delete Customer
        case "2":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.CustomerMenu();
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
                        Customer newCustomer = ui.GetCustomerDetailsForNewUser();
                        cfile.Create(newCustomer);
                        Console.WriteLine($"\nNew user: \n{newCustomer}");
                        Console.WriteLine($"Please save your customer id since its needed to order pizza! :)");
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
                        Console.Write("Enter your customer ID to update: ");
                        int customerToUpdate = int.Parse(Console.ReadLine() ?? "0");
                        Customer? CustomerObjSelected = cfile.CheckIdToUpdate(customerToUpdate);
                        if (CustomerObjSelected != null)
                        {
                            Console.WriteLine($"\nCurrent user info:\n{CustomerObjSelected}");
                            Customer? updatedCustomer = ui.GetCustomerDetailsToUpdateUser(CustomerObjSelected);
                            cfile.Update(updatedCustomer);
                            Console.WriteLine($"\nUpdated user:\n {updatedCustomer}");
                        }
                        else
                        {
                            Console.WriteLine("Customer not found. cannot update");
                            ui.Pause();
                            break;
                        }
                        
                        ui.Pause();
                        break;

                    // Delete Customer
                    case "5":
                        Console.WriteLine("\n--------------------------------------------");
                        Console.Write("Enter your customer ID to delete: ");
                        int customerIdToDelete = int.Parse(Console.ReadLine() ?? "0");
                        cfile.Delete(customerIdToDelete);
                        Console.WriteLine($"\nDeleted customer ID: {customerIdToDelete}");
                        ui.Pause();
                        break;

                    // Back to Main Menu
                    case "0":
                        back = true;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            break;

        //AdminMenu - PrintMenu, Create Pizza, Read Pizza, Update pizza, Delete pizza
        case "3":
            while (!back)
            {
                Console.WriteLine("\n--------------------------------------------");
                ui.AdminMenu();
                string? case2input = Console.ReadLine();
                switch (case2input)
                {
                    //PrintMenu
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
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            break;

        //Initiate Store.Start()
        case "4":
            Console.WriteLine("\n--------------------------------------------");
            store.Start();
            ui.Pause();
            Console.Clear();
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
