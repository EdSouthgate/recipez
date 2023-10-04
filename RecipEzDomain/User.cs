using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipEzDomain
{
    public class User
    {
        public string Id { get; set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Email { get; private set; }
        public string? Description { get; private set; }
        public List<Recipe> Recipes { get; private set; }

        private protected SHA256 sha256 { get; set; }

        private string? Password { get; set; }

        public User(string emailAddress, string password)
        {
            sha256 = SHA256.Create();
            try { 
                var tmp = new MailAddress(emailAddress);
            } 
            catch (FormatException)
            {
                throw new InvalidOperationException("Email address is not valid");
            }
            Email = emailAddress;
            SetPassword(password);
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
            if (password.Length < 8) { 
                throw new InvalidOperationException("Password must be at least 8 characters long");
            }
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$");
            if (!regex.IsMatch(password))
            {
                throw new InvalidOperationException("Password must contain at least one uppercase letter, one lowercase letter, one special character and one number");
            }
            Password = GetHashedstring(password);
        }

        public bool VerifyPassword(string enteredString)
        {
            return Password == GetHashedstring(enteredString);
        }

    }
}
