global using Wajba.Enums;
using Wajba.Dtos.ItemsDtos;

namespace Wajba.Dtos.Categories;

public class CategoryDto : EntityDto<int>
{

    public string? name { get; set; }
    public string? ImageUrl { get; set; }
    public Status status { get; set; }
    public string Description { get; set; }
    public ICollection<ItemDto>? ItemsDtos { get; set; }=new List<ItemDto>();
}
public class GetCategoryInput : PagedAndSortedResultRequestDto
{
    //public string? Filter { get; set; }
}
