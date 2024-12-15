global using AutoMapper;

namespace Wajba.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>().ForMember(c => c.ImageUrl, opt => opt.Ignore());
    }
}