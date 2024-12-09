using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Items;

namespace Wajba.OfferDomain
{
    public class OfferItem : FullAuditedEntity<int>
    {
        public int OfferId { get; set; } // Foreign Key
        public int ItemId { get; set; }  // Foreign Key
       
        // Navigation Properties
        public virtual Offer Offer { get; set; }
        public virtual Item Item { get; set; }
    }
}
