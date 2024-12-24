global using Wajba.Models.CurrenciesDomain;
global using Wajba.Dtos.CurrenciesContract;

namespace Wajba.CurrenciesService;

[RemoteService(false)]
public class CurrenciesAppService : ApplicationService
{
    private readonly IRepository<Currencies, int> _repository;

    public CurrenciesAppService(IRepository<Currencies, int> repository)
    {
        _repository = repository;
    }
    public async Task<CurrenciesDto> CreateAsync(CreateUpdateCurrenciesDto input)
    {
        Currencies currencies = new Currencies
        {
            Name = input.Name,
            Code = input.Code,
            ExchangeRate = input.ExchangeRate,
            IsCryptoCurrency = input.IsCryptoCurrency,
            Symbol = input.Symbol,
        };
        var insertedCategory = await _repository.InsertAsync(currencies, true);
        return ObjectMapper.Map<Currencies, CurrenciesDto>(insertedCategory);
    }
    public async Task<CurrenciesDto> UpdateAsync(int id, CreateUpdateCurrenciesDto input)
    {
        Currencies currencies = await _repository.GetAsync(id);
        currencies.Name = input.Name;
        currencies.Code = input.Code;
        currencies.ExchangeRate = input.ExchangeRate;
        currencies.IsCryptoCurrency = input.IsCryptoCurrency;
        currencies.Symbol = input.Symbol;
        currencies.LastModificationTime = DateTime.UtcNow;
        Currencies currencies1 = await _repository.UpdateAsync(currencies, true);
        return ObjectMapper.Map<Currencies, CurrenciesDto>(currencies);
    }
    public async Task<CurrenciesDto> GetByIdAsync(int id)
    {
        Currencies currencies = await _repository.GetAsync(id);
        return ObjectMapper.Map<Currencies, CurrenciesDto>(currencies);
    }
    public async Task<PagedResultDto<CurrenciesDto>> GetListAsync(GetinputCurrency input)
    {
        IQueryable<Currencies> queryable = await _repository.GetQueryableAsync();
        int totalCount = await AsyncExecuter.CountAsync(queryable);
        List<Currencies> currencies = await AsyncExecuter.ToListAsync(queryable
            .OrderBy(input.Sorting ?? nameof(Currencies.Name))
            .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<CurrenciesDto>(
            totalCount,
            ObjectMapper.Map<List<Currencies>, List<CurrenciesDto>>(currencies)
        );
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}