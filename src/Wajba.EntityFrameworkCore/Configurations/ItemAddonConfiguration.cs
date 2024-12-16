global using Wajba.Models.ItemAddonDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

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
