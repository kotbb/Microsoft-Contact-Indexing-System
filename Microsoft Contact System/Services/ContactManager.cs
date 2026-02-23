using Microsoft_Contact_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.Services
{
    internal class ContactManager : IContactService
    {
        private readonly List<Contact> _contacts = new List<Contact>();
        private int _nextId = 1;

        public ContactManager() { }
        public ContactManager(List<Contact> initialContacts)
        {
            if (initialContacts != null && initialContacts.Any())
            {
                _contacts = initialContacts;
                _nextId = _contacts.Max(c => c.Id) + 1;
            }
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _nextId++;
            _contacts.Add(contact);
        }

        public Contact RemoveContact(int id)
        {
            Contact contact = GetContactById(id);
            if (contact != null) 
            { 
                _contacts.Remove(contact);
                return contact;
            }
            return null;
        }
        public void EditContact(int id, Contact updatedContact)
        {
            Contact contact = GetContactById(id);
            if (contact == null) return;
            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
        }

        public List<Contact> FilterByDate(DateTime date)
        {
            List<Contact> filteredContacts = new List<Contact>();
            foreach (var contact in _contacts)
            {
                if (contact.CreationDate.Date == date.Date)
                    filteredContacts.Add(contact);
            }
            return filteredContacts;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            foreach (var contact in _contacts)
            {
                if(contact.Id == id)
                    return contact;
            }
            return null;
        }


        public List<Contact> Search(string keyword)
        {
            List<Contact> searchedContacts = new List<Contact>();

            foreach (var contact in _contacts)
            {
                if (contact.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    searchedContacts.Add(contact);
            }
            return searchedContacts;
        }
    }
}
