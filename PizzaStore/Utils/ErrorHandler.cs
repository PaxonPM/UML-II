using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Utils
{
    public static class ErrorHandler
    {


        public static void PrintError(Exception ex, string message = "")
        {
            var errorMessage = $"[Error] {message}\n" +
                               $"Message: {ex.Message}\n";
            Console.WriteLine(errorMessage);
        }

        public static void PrintGenericMessage(string message)
        {
            Console.WriteLine($"[Info] {message}");
        }

        public static void CustomerIdError(int id, string message)
        {
            throw new Exception($"{message}: {id}");
        }

        public static void PizzaNumberError(string key, string message)
        {
            throw new Exception($"{message}: {key}");
        }
    }
}
