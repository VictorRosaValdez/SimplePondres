using Microsoft.EntityFrameworkCore;
using SimplePondres.Models;

namespace SimplePondres.Dal
{
    public class SimplePondresDbContext : DbContext
    {
        // Properties for creating the tables in the SSMS with the EF.

        // Table of Product
        public DbSet<Product> Product { get; set; }

        // Table of Order
        public DbSet<Order> Order { get; set; }

        // Table of Order
        public DbSet<Company> Company { get; set; }

        /// <summary>
        /// Constructor for the use of the connection string in the Program.cs
        /// </summary>
        /// <param name="options"></param>
        public SimplePondresDbContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeded data for companies.
            modelBuilder.Entity<Company>().HasData(SeedHelper.GetCompanySeeds());

            // Seeded data for products.
            modelBuilder.Entity<Product>().HasData(SeedHelper.GetProductSeeds());

            // Seeded data for orders.
            modelBuilder.Entity<Order>().HasData(SeedHelper.GetOrderSeeds());

        }
    }
}
