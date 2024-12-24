global using Wajba.Models.ItemAttributeDomain;
global using Wajba.Dtos.ItemAttributes;

namespace Wajba.ItemAttributes;

[RemoteService(false)]
public class ItemAttributeAppService : ApplicationService
{
    private readonly IRepository<ItemAttribute, int> _repository;

    public ItemAttributeAppService(IRepository<ItemAttribute, int> repository)
    {
      _repository = repository;
    }
    public async Task<ItemAttributeDto> CreateAsync(CreateUpdateItemAttributeDto input)
    {
        ItemAttribute itemAttribute = new ItemAttribute
        {
            Name = input.Name,
            Status = input.Status,
        };
        ItemAttribute itemAttribute1 = await _repository.InsertAsync(itemAttribute,true);
        return ObjectMapper.Map<ItemAttribute, ItemAttributeDto>(itemAttribute1);
    }

}