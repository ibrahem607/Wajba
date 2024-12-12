using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Enums;

namespace Wajba.Languages
{
    public class CreateUpdateLanguageDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; } // File input for the image
        public Status Status { get; set; }
    }
}
