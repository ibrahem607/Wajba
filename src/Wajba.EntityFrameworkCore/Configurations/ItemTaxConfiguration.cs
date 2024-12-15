global using Wajba.Models.ItemTaxDomain;

namespace Wajba.Configurations
{
    public class ItemTaxConfiguration : IEntityTypeConfiguration<ItemTax>
    {
        public void Configure(EntityTypeBuilder<ItemTax> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(e => e.Code)
                .HasColumnType("decimal(18, 2)");



            builder.ToTable("ItemTaxes");
        }
    }
}
