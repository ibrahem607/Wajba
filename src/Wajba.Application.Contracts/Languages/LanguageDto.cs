using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wajba.Enums;

namespace Wajba.Languages
{
    public class LanguageDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
        public Status Status { get; set; }
    }
}
