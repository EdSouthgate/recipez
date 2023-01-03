using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipEz
{
    public class User
    {
        public string first { get; private set; }
        public string last { get; private set; }

        public string email { get; private set; }
        public User(string firstName, string lastName)
        {
            first = firstName;
            last = lastName;
        }

        public User(string firstName, string lastName, string emailAddress) {
            first = firstName;
            last = lastName;
            email = emailAddress;
        }
    }
}
