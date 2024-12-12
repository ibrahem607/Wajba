using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;
using Wajba.ItemVariationDomain;

namespace Wajba.ItemAttributeDomain
{
    public class ItemAttribute : FullAuditedEntity<int>
    {
        public string Name { get; set; } // e.g., "Size", "Drink", "Addons"
        public Status Status { get; set; }

        // Navigation property 
        public ICollection<ItemVariation> ItemVariations { get; set; } = new List<ItemVariation>();
    }
}
