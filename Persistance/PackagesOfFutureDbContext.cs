using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;

namespace Persistance
{
    public class PackagesOfFutureDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Sorting> Sortings { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=tcp:shaggy.database.windows.net,1433;" +
                                    "Initial Catalog=packages-of-future;" +
                                    "Persist Security Info=False;" +
                                    "User ID=PackagesOfFutureServiceAccount;" +
                                    "Password=SilneHaslo123$;" +
                                    "MultipleActiveResultSets=False;" +
                                    "Encrypt=True;" +
                                    "TrustServerCertificate=False;" +
                                    "Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public class ClientConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class SortingConfiguration : IEntityTypeConfiguration<Sorting>
    {
        public void Configure(EntityTypeBuilder<Sorting> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class DroneConfiguration : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
    
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}