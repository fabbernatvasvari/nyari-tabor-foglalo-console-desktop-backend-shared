using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    internal class Organizer: User
    {
        private string _phoneNumber;
        public Organizer(string name, int age, string email, string password, string phoneNumber) : base(name, age, email, password)
        {
            _phoneNumber = phoneNumber;
        }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}
