using Microsoft.EntityFrameworkCore;
using RecipEzDomain;

namespace RecipEzData
{
    public class PubContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase");
        }
    }
}