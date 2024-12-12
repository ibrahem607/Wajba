using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;

namespace Wajba.ItemTaxDomain
{
    public class ItemTax : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public decimal Code { get; set; }
        public int TaxRate { get; set; }
        public Status Status { get; set; }
    }
}
