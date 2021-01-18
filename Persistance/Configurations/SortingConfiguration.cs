using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SortingConfiguration : IEntityTypeConfiguration<Sorting>
    {
        public void Configure(EntityTypeBuilder<Sorting> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(x => x.Address).WithOne();
        }
    }
}