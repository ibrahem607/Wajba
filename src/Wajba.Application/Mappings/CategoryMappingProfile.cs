using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Categories;
using Wajba.Models.CategoriesDomain;

namespace Wajba.Mappings
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdateCategoryDto, Category>().ForMember(c => c.ImageUrl, opt => opt.Ignore());
        }
       
    }
}
