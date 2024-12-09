using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.ItemExtraDomain;

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
