using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.UI
{
    internal static class InputValidator
    {
        public static string GetValidEmail()
        {
            while (true)
            {
                Console.Write("Enter Email (Contains @ and .):");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Contains("@") &&
                    input.Contains("."))
                    return input.Trim();

                Console.WriteLine("Invalid email format. Try again.");
            }
        }
        public static string GetValidPhone() 
        {

            while (true)
            {
                Console.Write("Enter Phone Number (min 7 digits):");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.All(char.IsDigit) &&
                    input.Length >= 10)
                    return input.Trim();

                Console.WriteLine("Invalid phone number. Only digits allowed, min 7 digits.");
            }
        }

        public static string GetRequiredString(string message)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Value cannot be empty. Try again.");
            }
        }
        public static int GetValidInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number > 0)
                    return number;

                Console.WriteLine("Invalid number. Please enter a valid positive number.");
            }
        }
    }
}
