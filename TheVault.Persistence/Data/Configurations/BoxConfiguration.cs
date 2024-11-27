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

        builder.OwnsMany(b => b.Items, x =>
        {
            x.ToTable("Items");
            x.Property<int>("Id");
            x.HasKey("Id");
            x.WithOwner().HasForeignKey("BoxId");

            x.OwnsOne(i => i.Quantity, q =>
            {
                q.Property(y => y.Value).HasPrecision(18, 2);
                q.Property(y => y.QuantityType);
            });
        });

        builder.Navigation(x => x.Items)
            .AutoInclude();
    }
}
