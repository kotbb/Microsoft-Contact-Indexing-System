using Microsoft_Contact_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.Data
{
    internal interface IContactStorage
    {
        public List<Contact> LoadContacts();
        void SaveContacts(List<Contact> contacts);

    }
}
