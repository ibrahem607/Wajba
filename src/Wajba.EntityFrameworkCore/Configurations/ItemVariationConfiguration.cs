using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.ItemVariationDomain;

namespace Wajba.Configurations
{
    public class ItemVariationConfiguration : IEntityTypeConfiguration<ItemVariation>
    {
        public void Configure(EntityTypeBuilder<ItemVariation> builder)
        {
            builder.ConfigureByConvention();
           
            builder.Property(e => e.AdditionalPrice)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(e => e.Item)
                .WithMany(i => i.ItemVariations)
                .HasForeignKey(e => e.ItemId);

            builder.HasOne(e => e.ItemAttributes)
                .WithMany()
                .HasForeignKey(e => e.ItemAttributesId);

            builder.ToTable("ItemVariations");
        }
    }
}
