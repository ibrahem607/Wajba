﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.ItemAddonDomain;
using Wajba.CouponsDomain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Wajba.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
       
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.MaximumDiscount)
                  .HasColumnType("decimal(18, 2)");


            builder.Property(e => e.MinimumOrderAmount)
                .HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Code)
                .HasColumnType("decimal(18, 2)");


            builder.ToTable("coupons");
        }
    }
}