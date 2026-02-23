using Microsoft_Contact_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.UI
{
    internal static class ConsoleHelper
    {
        public static Contact CreateNewContact()
        {
            var name = InputValidator.GetRequiredString("Enter Name: ");
            var email = InputValidator.GetValidEmail();
            var phone = InputValidator.GetValidPhone();

            return new Contact(name, phone, email);
        }

        public static void DisplayContact(Contact contact)
        {
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Created At: {contact.CreationDate}");
            Console.WriteLine("----------------------------------");

        }

        public static void DisplayContacts(List<Contact> contacts)
        {
            if (!contacts.Any())
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            foreach (var contact in contacts)
                DisplayContact(contact);
        }
    }
}
