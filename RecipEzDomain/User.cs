using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RecipEzDomain
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public MailAddress Email { get; private set; }
        public string Description { get; private set; }
        public List<Recipe> Recipes { get; private set; }

        private SHA256 sha256 { get; set; }

        private string Password { get; set; }

        public User(string firstName, string lastName)
        {
            if (firstName.Count() < 3) { 
                throw new InvalidOperationException("First name must be at least 3 characters");
            }
            if(lastName.Count() < 3)
            {
                throw new InvalidOperationException("Last name must be at least 3 characters");
            }
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string emailAddress) {
            FirstName = firstName;
            LastName = lastName;
            try
            {
                Email = new MailAddress(emailAddress);
            } catch (FormatException)
            {
                throw new InvalidOperationException("Email address is not valid");
            }
            sha256 = SHA256.Create();
            Recipes = new List<Recipe>();
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
