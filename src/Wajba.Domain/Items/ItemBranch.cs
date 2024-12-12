using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Wajba.BranchDomain;

namespace Wajba.Items
{
    public class ItemBranch:Entity<int>
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
