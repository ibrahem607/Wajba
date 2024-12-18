using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Models.OTPDomain;

namespace Wajba.Configurations
{
    public class OTPConfiguration : IEntityTypeConfiguration<OTP>
    {
        public void Configure(EntityTypeBuilder<OTP> builder)
        {
            builder.ToTable("OTPs");
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.DigitLimit).IsRequired();
            builder.Property(x => x.ExpiryTimeInMinutes).IsRequired();
        }
    }
}