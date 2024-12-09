using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wajba.ItemAttributeDomain;

namespace Wajba.Configurations
{
    public class ItemAttributeConfiguration : IEntityTypeConfiguration<ItemAttribute>
    {
        public void Configure(EntityTypeBuilder<ItemAttribute> builder)
        {
            builder.ConfigureByConvention();
            builder.ToTable("ItemAttributes");
        }
    }
}
