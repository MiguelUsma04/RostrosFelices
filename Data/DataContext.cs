using Examen2.Models;
using Microsoft.EntityFrameworkCore; 
namespace Examen2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        public DbSet<User> Users { get; set; }

    }
}
