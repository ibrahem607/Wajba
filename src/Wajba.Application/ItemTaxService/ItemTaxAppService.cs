global using Wajba.Models.ItemTaxDomain;

namespace Wajba.ItemTaxService;

[RemoteService(false)]
public class ItemTaxAppService : ApplicationService
{
    private readonly IRepository<ItemTax, int> _repository;

    public ItemTaxAppService(IRepository<ItemTax, int> repository)
    {
      _repository = repository;
    }
}