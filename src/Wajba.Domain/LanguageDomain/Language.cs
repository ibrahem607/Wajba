using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;

namespace Wajba.LanguageDomain
{
    public class Language : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; } // Path or URL to the uploaded image
        public Status Status { get; set; }
    }
}
