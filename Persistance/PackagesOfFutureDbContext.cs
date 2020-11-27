using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;

namespace Persistance
{
    public class PackagesOfFutureDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Adresses { get; set; }

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

    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
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
}