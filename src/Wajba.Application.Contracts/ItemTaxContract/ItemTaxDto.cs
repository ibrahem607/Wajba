using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wajba.Enums;

namespace Wajba.ItemTaxContract
{
    public class ItemTaxDto : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal Code { get; set; }
        public int TaxRate { get; set; }
        public Status Status { get; set; }
    }
}
