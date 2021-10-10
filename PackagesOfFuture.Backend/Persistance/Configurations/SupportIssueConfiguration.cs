using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SupportIssueConfiguration : IEntityTypeConfiguration<SupportIssue>
    {
        public void Configure(EntityTypeBuilder<SupportIssue> builder)
        {
            builder.HasKey(d => d.Id);

            // builder.HasOne(x => x.User)
            //     .WithMany();
        }
    }
}