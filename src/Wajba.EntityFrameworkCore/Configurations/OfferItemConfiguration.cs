using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.ItemVariationDomain;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.OfferDomain;

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
