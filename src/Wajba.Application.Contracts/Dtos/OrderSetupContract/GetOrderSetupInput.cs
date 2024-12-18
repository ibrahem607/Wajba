using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Dtos.OrderSetupContract
{
    public class GetOrderSetupInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
