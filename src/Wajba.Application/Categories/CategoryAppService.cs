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
global using Wajba.Dtos.Categories;

namespace Wajba.Categories;

[RemoteService(false)]
public class CategoryAppService : ApplicationService
{
    private readonly IRepository<Category, int> _categoryRepository;
    private readonly IImageService _imageService;
    private readonly IRepository<Item, int> _itemRepo;

    public CategoryAppService(IRepository<Category, int> categoryRepository,
        IImageService imageService,
        IRepository<Item, int> itemRepo)
    {
        _categoryRepository = categoryRepository;
        _imageService = imageService;
        _itemRepo = itemRepo;
    }

    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        string? imageUrl = null;
        if (input.Image != null)
            imageUrl = await _imageService.UploadAsync(input.Image);
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
        Category category = await _categoryRepository.GetAsync(id);
        if (input.Image != null)
            category.ImageUrl = await _imageService.UploadAsync(input.Image);
        category.Name = input.name;
        category.Description = input.Description;
        category.Status = input.status;
        category.LastModificationTime = DateTime.UtcNow;
        Category updatedcategory = await _categoryRepository.UpdateAsync(category);
        return ObjectMapper.Map<Category, CategoryDto>(updatedcategory);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        Category category = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryInput input)
    {
        IQueryable<Category> queryable = await _categoryRepository.GetQueryableAsync();
        queryable = queryable.WhereIf(
            !string.IsNullOrWhiteSpace(input.Filter),
            c => c.Name.Contains(input.Filter) || c.Description.Contains(input.Filter)
        );
        int totalCount = await AsyncExecuter.CountAsync(queryable);
        List<Category> items = await AsyncExecuter.ToListAsync(queryable
            .OrderBy(input.Sorting ?? nameof(Category.Name))
            .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(items)
        );
    }

    public async Task<IReadOnlyList<CategoryDto>> Getallbybranchid(int branchid)
    {
        var queryable = await _categoryRepository.WithDetailsAsync(p => p.Items);
        var filteredCategories = queryable
    .Where(c => c.Items.Any(i => i.ItemBranches.Any(ib => ib.BranchId == branchid)))
    .ToList();
        ICollection<CategoryDto> categoryDtos = new List<CategoryDto>();
        foreach (var category in filteredCategories)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                name = category.Name,
                ItemsDtos = category.Items
           .Where(i => i.ItemBranches.Any(ib => ib.BranchId == branchid))
           .Select(i => new ItemDto
           {
               Id = i.Id,
               Name = i.Name,
           })
           .ToList()
            };
            categoryDtos.Add(categoryDto);
        }
        return (IReadOnlyList<CategoryDto>)categoryDtos;
    }

    public async Task DeleteAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}