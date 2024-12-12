using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wajba.Enums;

namespace Wajba.ItemAttributes
{
    public class ItemAttributeDto : EntityDto<int>
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
