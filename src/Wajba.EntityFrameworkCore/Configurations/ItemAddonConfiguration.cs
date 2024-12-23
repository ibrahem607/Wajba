global using Wajba.Models.ItemAddonDomain;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Volo.Abp.EntityFrameworkCore.Modeling;

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
