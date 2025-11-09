using System.Text.Json;
using PizzaStore.Interfaces;
using PizzaStore.Utils;

namespace PizzaStore.Customers
{
    public class CustomerFile : Icrud<string, int, Customer>
    {

        public string FilePath { get; private set; }
        public List<Customer> Customers { get; private set; } = new List<Customer>();


        public CustomerFile(string filePath)
        {
            FilePath = filePath;
            LoadCustomersFromJson(FilePath);
        }


        private void LoadCustomersFromJson(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                Customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customers: {ex.Message}");
                Customers = new List<Customer>();
            }
        }
        public Customer? CheckIdToUpdate(int customerId)
        {
            Customer? existingCustomer = Customers.FirstOrDefault(c => c.Id == customerId);
            return existingCustomer;
            
        }
        public void PrintAllCustomers()
        {
            Helpers.HelperPrintAllCustomers(Customers);
        }
        public void Create(Customer customerObj)
        {
            Customers.Add(customerObj);

            try
            {
                string jsonString = JsonSerializer.Serialize(Customers);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                ErrorHandler.PrintError(ex, "Error saving new customer");
            }
        }
        public void Read(string customerName)
        {
            Customer? customerToRead = Customers.FirstOrDefault(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));

            if (customerToRead != null)
            {
                Helpers.PrintCustomer(customerToRead, "You asked for this customer:");
            }
            else
            {
                ErrorHandler.PrintGenericMessage("Customer not found.\nReturning to Customer menu\n");
            }

        }
        public void Update(Customer customerObj)
        {
            Customer? existingCustomer = Customers.FirstOrDefault(c => c.Id == customerObj.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customerObj.Name;
                existingCustomer.Email = customerObj.Email;
                existingCustomer.Tlf = customerObj.Tlf;
                existingCustomer.AllCustomerOrders = customerObj.AllCustomerOrders;

                try
                {
                    string jsonString = JsonSerializer.Serialize(Customers);
                    File.WriteAllText(FilePath, jsonString);
                }
                catch (Exception ex)
                {
                    ErrorHandler.PrintError(ex, "Error updating customer");
                }
            }
            else
            {
                ErrorHandler.CustomerNotFound(customerObj.Id);
            }
        }
        public void Delete(int customerId)
        {
            Customer? customerToRemove = Customers.Find(c => c.Id == customerId);
            
            if (customerToRemove != null)
            {
                Customers.Remove(customerToRemove);

                try
                {
                    string jsonString = JsonSerializer.Serialize(Customers);
                    File.WriteAllText(FilePath, jsonString);
                }
                catch (Exception ex)
                {
                    ErrorHandler.PrintError(ex, "Error deleting customer");
                }
            }
            else
            {
                ErrorHandler.CustomerNotFound(customerId);
            }
        }
    }
}

