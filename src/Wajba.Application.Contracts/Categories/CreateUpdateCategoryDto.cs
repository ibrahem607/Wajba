using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wajba.Enums;

namespace Wajba.Categories
{
    public class CreateUpdateCategoryDto
    {
        public string? name { get; set; }
        public IFormFile? Image { get; set; }
        public Status status { get; set; }
        public string Description { get; set; }
    }
}
