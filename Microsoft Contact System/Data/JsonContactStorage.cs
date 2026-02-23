using Microsoft_Contact_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.Data
{
    internal class JsonContactStorage : IContactStorage
    {
        private const string _filePath = "contacts.json";
        public List<Contact> LoadContacts()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Contact>();

                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading contacts.");
                Console.WriteLine(ex.Message);
                return new List<Contact>();
            }
        }

        public void SaveContacts(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts);
            File.WriteAllText(_filePath, json);
        }
    }
}
