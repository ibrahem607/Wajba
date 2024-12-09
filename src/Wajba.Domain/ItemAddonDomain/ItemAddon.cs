using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Items;

namespace Wajba.ItemAddonDomain
{
    public class ItemAddon : FullAuditedEntity<int>
    {
        public string AddonName { get; set; }
        public decimal AdditionalPrice { get; set; }

        // Foreign key to Item
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}
