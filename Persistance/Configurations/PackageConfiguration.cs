using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(d => d.Id);
            
            builder.HasOne(o => o.Payment)
                .WithOne(p => p.Package)
                .HasForeignKey<Package>(x => x.Id);

            builder.HasOne(p => p.DeliveryAddress)
                .WithMany(a => a.PackagesDelivered);

            builder.HasOne(p => p.ReceiveAddress)
                .WithMany(a => a.PackagesReceived);
        }
    }
}