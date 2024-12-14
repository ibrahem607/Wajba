global using Wajba.Models.OfferDomain;

namespace Wajba.Configurations
{
    public class OfferItemConfiguration : IEntityTypeConfiguration<OfferItem>
    {
        

        public void Configure(EntityTypeBuilder<OfferItem> builder)
        {
            builder.ConfigureByConvention();

            builder.HasKey(oi => new { oi.OfferId, oi.ItemId });

            builder.HasOne(oi => oi.Offer)
            .WithMany(o => o.OfferItems)
            .HasForeignKey(oi => oi.OfferId);

            builder.HasOne(oi => oi.Item)
            .WithMany(i => i.OfferItems)
            .HasForeignKey(oi => oi.ItemId);


            builder.ToTable("OfferItems");
        }
    }
}
