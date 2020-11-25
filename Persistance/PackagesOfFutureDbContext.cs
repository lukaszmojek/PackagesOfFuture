using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance
{
    public class PackagesOfFutureDbContext : DbContext
    {
        public DbSet<Client> Blogs { get; set; }
        public DbSet<Address> Posts { get; set; }

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
    }
}