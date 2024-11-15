using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheVault.Domain.Boxes.Entities;

namespace TheVault.Persistence.Data.Configurations;

public class BoxConfiguration : IEntityTypeConfiguration<Box>
{
    public void Configure(EntityTypeBuilder<Box> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Label);
        builder.Property(b => b.Location);
        builder.Property(b => b.Description);

        builder.HasMany(b => b.Items)
            .WithOne()
            .HasForeignKey("BoxId");

        builder.Navigation(x => x.Items)
            .AutoInclude();
    }
}
