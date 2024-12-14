global using Microsoft.AspNetCore.Http;

namespace Wajba.Dtos.Categories;

public class CreateUpdateCategoryDto
{
    public string? name { get; set; }
    public IFormFile? Image { get; set; }
    public Status status { get; set; }
    public string Description { get; set; }
}
