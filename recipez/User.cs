using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipEz
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string emailAddress) {
            FirstName = firstName;
            LastName = lastName;
            Email = emailAddress;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
