global using Wajba.Models.ItemExtraDomain;

namespace Wajba.Configurations
{
    public class ItemExtraConfiguration : IEntityTypeConfiguration<ItemExtra>
    {
        public void Configure(EntityTypeBuilder<ItemExtra> builder)
        {
            builder.ConfigureByConvention();

            builder.HasOne(e => e.Item)
                .WithMany(i => i.ItemExtras)
                .HasForeignKey(e => e.ItemId);

            builder.Property(e => e.AdditionalPrice)
                .HasColumnType("decimal(18, 2)");

            builder.ToTable("ItemExtras");
        }
    }
}
