using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft_Contact_System.Data;
using Microsoft_Contact_System.Models;
using Microsoft_Contact_System.Services;
using Microsoft_Contact_System.UI;


namespace Microsoft_Contact_System
{
    internal class Program
    {
        static void Main()
        {
            IContactService service = new ContactManager();
            IContactStorage storage = new JsonContactStorage();

            var contacts = storage.LoadContacts();
            foreach (var c in contacts)
                service.AddContact(c);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\n***** Contact Manager *****");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. View Contact");
                Console.WriteLine("5. List Contacts");
                Console.WriteLine("6. Search By Name");
                Console.WriteLine("7. Filter By Date");
                Console.WriteLine("8. Save");
                Console.WriteLine("9. Exit");

                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var newContact = ConsoleHelper.CreateNewContact();
                        service.AddContact(newContact);
                        Console.WriteLine("Contact is added successfully!");
                        ConsoleHelper.DisplayContact(newContact);
                        break;

                    case "2":
                        int editId = InputValidator.GetValidInt("Enter Contact Id: ");

                        var existing = service.GetContactById(editId);

                        if (existing == null)
                        {
                            Console.WriteLine("Contact not found.");
                            break;
                        }

                        string newName = InputValidator.GetRequiredString("New Name: ");
                        string newEmail = InputValidator.GetValidEmail();
                        string newPhone = InputValidator.GetValidPhone();

                        Contact updatedContact = new Contact(newName, newPhone, newEmail);
                        service.EditContact(editId, updatedContact);
                        Console.WriteLine("Contact is updated successfully!");
                        ConsoleHelper.DisplayContact(service.GetContactById(editId));

                        break;

                    case "3":
                        int deleteId = InputValidator.GetValidInt("Enter Contact Id: ");
                        var deletedContact = service.RemoveContact(deleteId);
                        ConsoleHelper.DisplayContact(deletedContact);
                        Console.WriteLine($"This contact is deleted successfully!");
                        break;

                    case "4":
                        var id = InputValidator.GetValidInt("Enter Contact Id: ");
                        var contact = service.GetContactById(id);
                        ConsoleHelper.DisplayContact(contact);
                        break;

                    case "5":
                        ConsoleHelper.DisplayContacts(service.GetAllContacts());
                        break;

                    case "6":
                        string keyword = InputValidator.GetRequiredString("Enter name to search: ");
                        var results = service.Search(keyword);
                        ConsoleHelper.DisplayContacts(results);
                        break;

                    case "7":
                        Console.Write("Enter date (dd/mm/yyyy): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                        {
                            var filtered = service.FilterByDate(date);
                            Console.WriteLine(date);
                            ConsoleHelper.DisplayContacts(filtered);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "8":
                        storage.SaveContacts(service.GetAllContacts());
                        Console.WriteLine("Saved successfully.");
                        break;

                    case "9":
                        flag = false;
                        Console.WriteLine("Exiting the Program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }
    }
}