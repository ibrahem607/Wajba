global using AutoMapper;
global using Wajba.Categories;
using Wajba.Dtos.Categories;

namespace Wajba.Mappings;

public class CategoryMappingProfile:Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>().ForMember(c => c.ImageUrl, opt => opt.Ignore());
    }
   
}
