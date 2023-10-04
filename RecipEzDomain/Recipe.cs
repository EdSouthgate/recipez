using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipEzDomain
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; private set; }

        public  Recipe(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
