namespace Wajba.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(e => e.DiscountPercentage)
            .HasColumnType("decimal(18, 2)");
      


        builder.ToTable("offers");
    }
}
