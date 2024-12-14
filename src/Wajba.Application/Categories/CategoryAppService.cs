global using System.Collections.Generic;
global using System.Linq;
global using System.Linq.Dynamic.Core;
global using System.Threading.Tasks;
global using Volo.Abp;
global using Volo.Abp.Application.Dtos;
global using Volo.Abp.Application.Services;
global using Volo.Abp.Domain.Repositories;
global using Wajba.Models.CategoriesDomain;
global using Wajba.Services.ImageService;
using Wajba.Dtos.Categories;

namespace Wajba.Categories;

[RemoteService(false)]
public class CategoryAppService:ApplicationService
{
    private readonly IRepository<Category, int> _categoryRepository;
    private readonly IImageService _imageService;

    public CategoryAppService(IRepository<Category, int> categoryRepository, IImageService imageService)
    {
        _categoryRepository = categoryRepository;
        _imageService = imageService;
    }

    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        string? imageUrl = null;

        if (input.Image != null)
        {
            imageUrl = await _imageService.UploadAsync(input.Image);
        }

        var category = new Category
        {
            Name = input.name,
            Description = input.Description,
            ImageUrl = imageUrl,
            Status = input.status
        };

        var insertedCategory = await _categoryRepository.InsertAsync(category);
        return ObjectMapper.Map<Category, CategoryDto>(insertedCategory);

    }

    public async Task<CategoryDto> UpdateAsync(int id, CreateUpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        if (input.Image != null)
        {
            category.ImageUrl = await _imageService.UploadAsync(input.Image);
        }

        category.Name = input.name;
        category.Description = input.Description;
        category.Status = input.status;

        var updatedcategory=await _categoryRepository.UpdateAsync(category);

        return ObjectMapper.Map<Category, CategoryDto>(updatedcategory);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryInput input)
    {
        // Get IQueryable from the repository
        var queryable = await _categoryRepository.GetQueryableAsync();

        // Apply conditional filtering using WhereIf
        queryable = queryable.WhereIf(
            !string.IsNullOrWhiteSpace(input.Filter),
            c => c.Name.Contains(input.Filter) || c.Description.Contains(input.Filter)
        );

        // Count the total items
        var totalCount = await AsyncExecuter.CountAsync(queryable);

        // Apply sorting, paging, and execute the query
        var items = await AsyncExecuter.ToListAsync(queryable
            .OrderBy(input.Sorting ?? nameof(Category.Name))
            .PageBy(input.SkipCount, input.MaxResultCount));

        // Map and return the result
        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(items)
        );
    }

    public async Task DeleteAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}
