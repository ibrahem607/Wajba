using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Enums;

namespace Wajba.ItemAttributes
{
    public class CreateUpdateItemAttributeDto
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
