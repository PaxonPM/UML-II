
using PizzaStore.Customers;
using PizzaStore.Pizzas;
using PizzaStore.UI;

namespace PizzaStore
{
    public class Store
    {


        public void Start()
        {
            // TUTORIAL STARTS HERE
            #region Initial Greeting

            ConsoleUI uiTutorial = new ConsoleUI();
            Console.WriteLine(@"
              _   _      _ _       
             | | | | ___| | | ___  
             | |_| |/ _ \ | |/ _ \ 
             |  _  |  __/ | | (_) |
             |_| |_|\___|_|_|\___/ 
                                
                     o/
                    /|      
                    / \
              ----------------
               W E L C O M E !
              ----------------
            ");
            #endregion

            // CUSTOMER FILE TUTORIAL STARTS HERE
            #region Intro and loading CustomerFile
            string[] lines =
            {
                "Welcome to the tutorial!",
                "Here we will implement code to test the two new implemneted classes (CustomerFile and PizzaMenu) and their methods.",
                "We will start by creating an object of the CustomerFile class which will load the customers from the customers.json file.",

            };
            uiTutorial.PrintLinesSlowly(lines);
            CustomerFile cFileTutorial = new CustomerFile("Data/customers.json");
            uiTutorial.Pause();
            #endregion

            #region Check loaded customers
            lines = new string[]
            {
                "The CustomerFile object has now been created and the customers have been loaded from the JSON file.",
                "Next, we will print all the premade customers to the console to verify that they have been loaded correctly.",
                "Let's see the output below:",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            cFileTutorial.PrintCustomerFile();
            uiTutorial.Pause();
            #endregion

            #region Create Customer
            lines = new string[]
            {
                "As you can see, all the customers from the JSON file have been printed to the console.",
                "Next, we will test the CRUD methods of the CustomerFile class.",
                "Let's start by creating a new customer and adding it to the CustomerFile.",
                "Please enter the details for the new customer below:",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Customer newCustomer = uiTutorial.GetCustomerDetailsForNewUser();
            cFileTutorial.Create(newCustomer);
            Console.WriteLine($"\nNew user: \n{newCustomer}");
            uiTutorial.Pause();
            #endregion

            #region Read Customer
            lines = new string[]
            {
                "we have successfully added the new customer to the CustomerFile.",
                "Next, we will read a customer by their name.",

            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Console.Write("Enter your customer Name: ");
            string customerName = Console.ReadLine() ?? "";
            cFileTutorial.Read(customerName);
            uiTutorial.Pause();
            #endregion 

            #region Update Customer
            lines = new string[]
            {
                "Now, we will update an existing customer.",
                
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Console.Write("Enter your customer ID to update: ");
            int customerToUpdate = int.Parse(Console.ReadLine() ?? "0");
            Customer? CustomerObjSelected = cFileTutorial.CheckIdToUpdate(customerToUpdate);
            if (CustomerObjSelected != null)
            {
                Console.WriteLine($"\nCurrent user info:\n{CustomerObjSelected}");
                Customer? updatedCustomer = uiTutorial.GetCustomerDetailsToUpdateUser(CustomerObjSelected);
                cFileTutorial.Update(updatedCustomer);
                Console.WriteLine($"\nUpdated user:\n {updatedCustomer}");
            }
            else
            {
                Console.WriteLine("Customer not found. cannot update");
                uiTutorial.Pause();
                
            }

            uiTutorial.Pause();
            #endregion

            #region How the customer file looks now
            lines = new string[]
            {
                "Alright! We have now tested the Create, Read, and Update methods of the CustomerFile class.",
                "Time to check how the customerFile looks now with all the changes we have made.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            cFileTutorial.PrintCustomerFile();
            uiTutorial.Pause();
            #endregion

            #region Delete Customer
            lines = new string[]
            {
                "Time for the last part for the customerFile, which is deleting a customer.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Console.Write("Enter your customer ID to delete: ");
            int customerIdToDelete = int.Parse(Console.ReadLine() ?? "0");
            cFileTutorial.Delete(customerIdToDelete);
            Console.WriteLine($"\nDeleted customer ID: {customerIdToDelete}");
            uiTutorial.Pause();
            #endregion

            #region ending customer file tutorial part
            lines = new string[]
            {
                "We have now tested all the CRUD methods of the CustomerFile class.",
                "Here is how the CustomerFile looks after we deleted a customer",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            cFileTutorial.PrintCustomerFile();
            uiTutorial.Pause();
            #endregion

            // PIZZA MENU TUTORIAL STARTS HERE
            #region Start Pizza Menu Tutorial amd Print Current Menu

            lines = new string[]
           {
                "We now move on to testing the PizzaMenu class and its methods.",
                "Let's start by creating an object of the PizzaMenu class which will load the pizzas from the pizzas.json file.",
                
           };
            uiTutorial.PrintLinesSlowly(lines);
            PizzaMenu pizzaMenuTutorial = new PizzaMenu("Data/pizzas.json");
            uiTutorial.Pause();
            lines = new string[]
                {
                 "The PizzaMenu object has now been created and the pizzas have been loaded from the JSON file.",
                 "Next, we will print all the premade pizzas to the console to verify that they have been loaded correctly.",
                 "Let's see the output below:",
                };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            pizzaMenuTutorial.PrintMenu();
            uiTutorial.Pause();
            #endregion

            #region Create Pizza
            lines = new string[]
            {
                "As you can see, all the pizzas from the JSON file have been printed to the console.",
                "Now, we will test the CRUD methods of the PizzaMenu class.",
                "Let's start by creating a new pizza and adding it to the PizzaMenu.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Pizza newPizza = uiTutorial.GetPizzaDetailsFromAdmin();
            pizzaMenuTutorial.Create(newPizza);
            Console.WriteLine($"\nNew pizza added: \n{newPizza}");
            uiTutorial.Pause();
            #endregion

            #region Read Pizza

            lines = new string[]
            {
                "We have successfully added the new pizza to the PizzaMenu.",
                "Next, we will read a pizza by its number.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Console.Write("Enter the Pizza number to find: ");
            string pizzaNumber = Console.ReadLine() ?? "";
            pizzaMenuTutorial.Read(pizzaNumber);
            uiTutorial.Pause();
            #endregion

            #region Update Pizza
            lines = new string[]
            {
                "Now, we will update an existing pizza.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Pizza updatedPizza = uiTutorial.GetPizzaDetailsFromAdmin();
            pizzaMenuTutorial.Update(updatedPizza);
            Console.WriteLine($"\nUpdated pizza: {updatedPizza}");
            uiTutorial.Pause();
            #endregion

            #region How the pizza menu looks now
            lines = new string[]
            {
                "Alright! We have now tested the Create, Read, and Update methods of the PizzaMenu class.",
                "Time to check how the PizzaMenu looks now with all the changes we have made.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            pizzaMenuTutorial.PrintMenu();
            uiTutorial.Pause();
            #endregion

            #region Delete Pizza
            lines = new string[]
            {
                "Time for the last part for the PizzaMenu, which is deleting a pizza.",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            Console.Write("Enter Pizza Number to delete: ");
            string? pizzaNumberToDelete = Console.ReadLine() ?? "";
            pizzaMenuTutorial.Delete(pizzaNumberToDelete);
            Console.WriteLine($"\nDeleted pizza number: {pizzaNumberToDelete}");
            uiTutorial.Pause();
            #endregion

            #region Final Pizza Menu and ending tutorial

            lines = new string[]
            {
                "We have now tested all the CRUD methods of the PizzaMenu class.",
                "Here is how the PizzaMenu looks after we deleted a pizza",
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            pizzaMenuTutorial.PrintMenu();
            uiTutorial.Pause();


            lines = new string[]
            {
            "This concludes the tutorial on how to use the CustomerFile and PizzaMenu classes.",
                "Thank you for following along!"
            };
            uiTutorial.PrintLinesSlowly(lines);
            uiTutorial.Pause();
            #endregion



        }
    }   
}
