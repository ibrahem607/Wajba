﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;
using Wajba.ItemAttributeDomain;
using Wajba.Items;

namespace Wajba.ItemVariationDomain
{
    public class ItemVariation : FullAuditedEntity<int>
    {
        public string Name { get; set; } // e.g., "Single", "Double", "Coke", "Pepsi"
        public string Note { get; set; }
        public Status Status { get; set; }
        public decimal AdditionalPrice { get; set; }

        // Foreign key to ItemAttributes
        public int ItemAttributesId { get; set; }
        public ItemAttribute? ItemAttributes { get; set; }

        // Foreign key to Item
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}