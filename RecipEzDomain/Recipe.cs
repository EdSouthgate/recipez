using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipEzDomain
{
    public class Recipe
    {
        public string Name { get; private set; }

        public  Recipe(string name)
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
