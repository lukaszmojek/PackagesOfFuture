using System.Reflection;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PackagesOfFutureDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Sorting> Sortings { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SupportIssue> SupportIssues { get; set; }

        public PackagesOfFutureDbContext(DbContextOptions<PackagesOfFutureDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}