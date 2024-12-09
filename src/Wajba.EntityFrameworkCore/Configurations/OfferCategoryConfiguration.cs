using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.OfferDomain;

namespace Wajba.Configurations
{
    public class OfferCategoryConfiguration : IEntityTypeConfiguration<OfferCategory>
    {
        public void Configure(EntityTypeBuilder<OfferCategory> builder)
        {
            builder.ConfigureByConvention();

            builder.HasKey(oc => new { oc.OfferId, oc.CategoryId });

            builder.HasOne(oc => oc.Offer)
            .WithMany(o => o.OfferCategories)
            .HasForeignKey(oc => oc.OfferId);

            builder.HasOne(oc => oc.Category)
            .WithMany(c => c.OfferCategories)
            .HasForeignKey(oc => oc.CategoryId);


            builder.ToTable("OfferCategories");
        }
    }
}
