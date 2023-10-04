// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RecipEzData;
using RecipEzDomain;

using (PubContext context = new PubContext())
{
    // Create database
    context.Database.EnsureCreated();
}

GetUsers();


void AddUser() {
    var user = new User("jimsmith@example.com", "password");
    user.SetDescription("Big old lovely jim");
    user.Recipes.Add(new Recipe("Ham sandwich"));
    user.Recipes.Add(new Recipe("Jam sandwich"));
    user.Recipes.Add(new Recipe("Egg sandwich"));
    using var context = new PubContext();
    context.Users.Add(user);
    context.SaveChanges();
}

void GetUsers()
{
    using (PubContext context = new PubContext())
    {
        var users = context.Users.Include(u => u.Recipes).ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} : {user.Email}");
            Console.WriteLine($"\t{user.Description}");
            Console.WriteLine($"\tRecipes: {user}");
            foreach (var recipe in user.Recipes)
            {
                Console.WriteLine($"\t{recipe.Name}");
            }
        }
    }
}
