using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.ItemAddonDomain;

namespace Wajba.Configurations
{
    public class ItemAddonConfiguration : IEntityTypeConfiguration<ItemAddon>
    {
        public void Configure(EntityTypeBuilder<ItemAddon> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(e => e.AdditionalPrice)
                .HasColumnType("decimal(18, 2)");


            builder.ToTable("ItemAddons");
        }
    }
}
