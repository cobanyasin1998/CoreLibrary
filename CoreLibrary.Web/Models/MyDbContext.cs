using Microsoft.EntityFrameworkCore;

namespace CoreLibrary.Web.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
