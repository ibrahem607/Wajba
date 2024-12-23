global using Wajba.Dtos.ItemsDtos;
global using Wajba.Models.Items;
using Volo.Abp.Application.Dtos;

namespace Wajba.ItemServices;

public class ItemAppServices : ApplicationService
{
    private readonly IRepository<Item, int> _repository;
    private readonly IRepository<Category, int> _repository1;
    private readonly IImageService _imageService;

    public ItemAppServices(IRepository<Item, int> repository, IRepository<Category, int> repository1, IImageService imageService)
    {
        _repository = repository;
        _repository1 = repository1;
        _imageService = imageService;
    }
    public async Task<ItemDto> CreateAsync(CreateItemDto input)
    {
        string? imageUrl = null;
        if (input.ImageUrl != null)
            imageUrl = await _imageService.UploadAsync(input.ImageUrl);
        Category category = await _repository1.FindAsync(input.CategoryId);
        if (category == null)
            return null;

        Item item = new Item()
        {
            Name = input.Name,
            Description = input.Description,
            ImageUrl = imageUrl,
            CategoryId = input.CategoryId,
            IsFeatured = input.IsFeatured,
            TaxValue = input.TaxValue,
            Price = input.Price,
            ItemType = (Enums.ItemType)input.ItemType,
            Note = input.Note,
            Status = (Enums.Status)input.status,
            IsDeleted = false,
        };
        await _repository.InsertAsync(item);
        return ObjectMapper.Map<Item, ItemDto>(item);
    }
    public async Task<PagedResultDto<ItemDto>> GetAll(GetItemInput input)
    {
        var queryable = await _repository.GetQueryableAsync();
        queryable = queryable.WhereIf(
            !string.IsNullOrEmpty(input.name), p => p.Name.ToLower() == input.name.ToLower())
            .WhereIf(input.BranchId.HasValue, p => p.ItemBranches.Any(l => l.BranchId == input.BranchId.Value));
        int totalCount = await AsyncExecuter.CountAsync(queryable);
        List<Item> items = await AsyncExecuter.ToListAsync(queryable
            .OrderBy(input.Sorting ?? nameof(Item.Name))
            .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<ItemDto>(
totalCount,
ObjectMapper.Map<List<Item>, List<ItemDto>>(items)
);
    }
}