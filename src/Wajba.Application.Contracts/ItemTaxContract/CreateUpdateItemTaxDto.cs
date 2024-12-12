using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Enums;

namespace Wajba.ItemTaxContract
{
    public class CreateUpdateItemTaxDto
    {
        public string Name { get; set; }
        public decimal Code { get; set; }
        public int TaxRate { get; set; }
        public Status Status { get; set; }
    }
}
