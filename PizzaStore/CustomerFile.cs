using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace PizzaStore
{
    public class CustomerFile : Icrud<int, Customer>
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
                Console.WriteLine($"Error saving customers: {ex.Message}");
            }
        }

        public bool CheckIdToUpdate(int customerId)
        {
            Customer? existingCustomer = Customers.FirstOrDefault(c => c.Id == customerId);
            if (existingCustomer == null)
            {
                return false;
            }
            else
            {
                return true;
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

                try
                {
                    string jsonString = JsonSerializer.Serialize(Customers);
                    File.WriteAllText(FilePath, jsonString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving customer: {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"Customer with ID {customerObj.Id} doesn't exist");
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
                    Console.WriteLine($"Error saving customers: {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"Customer with ID {customerId} doesn't exist");
            }
        }
        public void Read(int customerId)
        {
            Customer? customerToRead = Customers.FirstOrDefault(c => c.Id == customerId);
            
            if (customerToRead != null)
            {
                Console.WriteLine($"You asked for this customer: \n{customerToRead}");
            }
            else
            {
                throw new Exception($"Customer with ID {customerId} doesn't exist");
            }
            
        }

        public void PrintAllCustomers()
        {
            foreach (Customer customer in Customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}

