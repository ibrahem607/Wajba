global using Wajba.Models.ItemAttributeDomain;

namespace Wajba.Configurations;

public class ItemAttributeConfiguration : IEntityTypeConfiguration<ItemAttribute>
{
    public void Configure(EntityTypeBuilder<ItemAttribute> builder)
    {
        builder.ConfigureByConvention();
        builder.ToTable("ItemAttributes");
    }
}
