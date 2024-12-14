global using Wajba.ItemAddonDomain;

namespace Wajba.Configurations;

public class ItemAddonConfiguration : IEntityTypeConfiguration<ItemAddon>
{
    public void Configure(EntityTypeBuilder<ItemAddon> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(e => e.AdditionalPrice)
            .HasColumnType("decimal(18, 2)");


        builder.ToTable("ItemAddons");
    }
}
