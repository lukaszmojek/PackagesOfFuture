using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(a => a.PackagesDelivered)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(a => a.DeliveryAddressId);
            
            builder.HasMany(a => a.PackagesReceived)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(a => a.ReceiveAddressId);
        }
    }
}