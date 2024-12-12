﻿using Volo.Abp.Application.Dtos;
using Wajba.Enums;

namespace Wajba.Categories
{
    public class CategoryDto:EntityDto<int>
    {
        
        public string? name { get; set; }
        public string? ImageUrl { get; set; }
        public Status status { get; set; }
        public string Description { get; set; }
    }
    public class GetCategoryInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
