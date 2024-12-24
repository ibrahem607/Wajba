global using Wajba.Dtos.ItemsDtos;
global using Wajba.Models.Items;

namespace Wajba.ItemServices;

public class ItemAppServices : ApplicationService
{
    private readonly IRepository<Item, int> _repository;
    private readonly IRepository<Category, int> _repository1;
    private readonly IRepository<Branch, int> _repository2;
    private readonly IImageService _imageService;

    public ItemAppServices(IRepository<Item, int> repository, 
        IRepository<Category, int> repository1, 
        IRepository<Branch,int> repository2,
        IImageService imageService)
    {
        _repository = repository;
        _repository1 = repository1;
       _repository2 = repository2;
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
        IList<Branch> branches = new List<Branch>();
        foreach(var i in input.BranchIds)
        {
            Branch branch = await _repository2.FindAsync(i);
            if(branch==null)
                return null;
            branches.Add(branch);
        }
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
            ItemBranches = branches.Select(branch => new ItemBranch { Branch = branch }).ToList()
        };
        await _repository.InsertAsync(item,true);
        return ObjectMapper.Map<Item, ItemDto>(item);
    }
    public async Task UpdateItemImage(UpdateItemImageDTO updateItemDTO)
    {
        Item item = await _repository.FindAsync(updateItemDTO.Id);
        if (item == null) return;
        if (updateItemDTO.newImage != null)
            item.ImageUrl = await _imageService.UploadAsync(updateItemDTO.newImage);
        item.LastModificationTime = DateTime.UtcNow;
        await _repository.UpdateAsync(item, true);
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
    public async Task<ItemDto> UpdateAsync(int id, CreateItemDto input)
    {
        Category category = await _repository1.FindAsync(input.CategoryId);
        if (category == null)
            return null;

        Item item = await _repository.GetAsync(id);
        if (item == null)
            return null;
        if (input.ImageUrl != null)
            item.ImageUrl = await _imageService.UploadAsync(input.ImageUrl);
        item.Name = input.Name;
        item.Description = input.Description;
        item.Status = (Enums.Status)input.status;
        item.Note = input.Note;
        item.CategoryId = input.CategoryId;
        item.IsFeatured = input.IsFeatured;
        item.ItemType = (Enums.ItemType)input.ItemType;
        item.Price=input.Price;
        item.TaxValue=input.TaxValue;
      
        item.LastModificationTime = DateTime.UtcNow;
        Item item1 = await _repository.UpdateAsync(item, true);
        return ObjectMapper.Map<Item, ItemDto>(item1);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}