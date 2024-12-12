using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.CategoriesDomain;
using Wajba.OfferDomain;

namespace Wajba.Configurations
{
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
}
