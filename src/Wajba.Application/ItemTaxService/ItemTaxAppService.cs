global using Wajba.Models.ItemTaxDomain;
global using Wajba.Dtos.ItemTaxContract;

namespace Wajba.ItemTaxService;

[RemoteService(false)]
public class ItemTaxAppService : CrudAppService<
ItemTax,
ItemTaxDto,
int,
PagedAndSortedResultRequestDto,
CreateUpdateItemTaxDto>,
IItemTaxAppService
{
    public ItemTaxAppService(IRepository<ItemTax, int> repository)
        : base(repository)
    {
    }
}