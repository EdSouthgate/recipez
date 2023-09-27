// See https://aka.ms/new-console-template for more information
using RecipEzData;

using (PubContext context = new PubContext())
{
    // Create database
    context.Database.EnsureCreated();
}

GetUsers();

void GetUsers()
{
    using (PubContext context = new PubContext())
    {
        var users = context.Users.ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} ${user.LastName} : ${user.Email}");
        }
    }
}
