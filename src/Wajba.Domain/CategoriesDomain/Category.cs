using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Wajba.Enums;
using Wajba.Items;
using Wajba.OfferDomain;

namespace Wajba.CategoriesDomain
{
    public class Category : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        // Navigation properties
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public virtual ICollection<OfferCategory> OfferCategories { get; set; } = new List<OfferCategory>();
    }
}
