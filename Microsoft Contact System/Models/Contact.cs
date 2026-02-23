using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Contact_System.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Contact(string name, string phone, string email)
        {

            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
