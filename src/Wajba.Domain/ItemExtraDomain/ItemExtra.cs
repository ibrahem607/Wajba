using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;
using Wajba.Items;

namespace Wajba.ItemExtraDomain
{
    public class ItemExtra : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public decimal AdditionalPrice { get; set; }

        // Foreign key to Item
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}
