using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private SHA256 sha256 { get; set; }

        private string Password { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string emailAddress) {
            FirstName = firstName;
            LastName = lastName;
            Email = emailAddress;
            sha256 = SHA256.Create();
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        private string GetHashedstring(string stringToBeHashed) 
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToBeHashed));          
            StringBuilder builder = new StringBuilder();
            for(int i =0; i< bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public void SetPassword(string password)
        {      
            Password = GetHashedstring(password);
        }

        public bool VerifyPassword(string enteredString)
        {
            return Password == GetHashedstring(enteredString);
        }

    }
}
