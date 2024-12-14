namespace Wajba.Dtos.CurrenciesContract
{
    public interface ICurrenciesAppService :
    ICrudAppService<
        CurrenciesDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateCurrenciesDto>
    {
    }
}
