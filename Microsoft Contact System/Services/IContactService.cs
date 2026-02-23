using Microsoft_Contact_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.Services
{
    internal interface IContactService
    {
        void AddContact(Contact contact);
        void EditContact(int id, Contact updatedContact);
        Contact RemoveContact(int id);
        Contact GetContactById(int id);
        List<Contact> GetAllContacts();
        List<Contact> Search(string keyword);
        List<Contact> FilterByDate(DateTime date);

    }
}
