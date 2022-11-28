using Microsoft.EntityFrameworkCore;

namespace Project.FluentValidation.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}
