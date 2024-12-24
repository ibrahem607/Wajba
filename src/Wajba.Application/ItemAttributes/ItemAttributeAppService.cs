global using Wajba.Models.ItemAttributeDomain;

namespace Wajba.ItemAttributes;

[RemoteService(false)]
public class ItemAttributeAppService : ApplicationService
{
    private readonly IRepository<ItemAttribute, int> _repository;

    public ItemAttributeAppService(IRepository<ItemAttribute, int> repository)
    {
      _repository = repository;
    }
    
}