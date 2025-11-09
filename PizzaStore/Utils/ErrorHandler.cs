using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Utils
{
    public static class ErrorHandler
    {


        public static void PrintError(Exception ex, string contextMessage = "")
        {
            var errorMessage = $"[Error] {contextMessage}\n" +
                               $"Message: {ex.Message}\n";
            Console.WriteLine(errorMessage);
        }

        public static void PrintGenericMessage(string message)
        {
            Console.WriteLine($"[Info] {message}");
        }

        public static void CustomerNotFound(int id)
        {
            throw new Exception($"Customer with ID {id} not found.");
        }
    }
}
