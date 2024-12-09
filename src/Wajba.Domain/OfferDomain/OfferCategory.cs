using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.CategoriesDomain;

namespace Wajba.OfferDomain
{
    public class OfferCategory : FullAuditedEntity<int>
    {
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
      
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
