using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.Models.ItemTaxDomain;

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
