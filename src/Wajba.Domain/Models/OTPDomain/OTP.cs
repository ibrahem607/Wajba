using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Models.OTPDomain
{
    public class OTP : FullAuditedEntity<int> 
    {
        public OTPType Type { get; set; }
        public int DigitLimit { get; set; }
        public int ExpiryTimeInMinutes { get; set; }
    }
}
