namespace Wajba.Dtos.ItemTaxContract;

public interface IItemTaxAppService :
ICrudAppService<
    ItemTaxDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateItemTaxDto>
{
}
