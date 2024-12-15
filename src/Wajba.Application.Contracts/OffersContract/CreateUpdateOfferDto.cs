using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Enums;

namespace Wajba.OffersContract
{
    public class CreateUpdateOfferDto
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DiscountType DiscountType { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
    }
}
