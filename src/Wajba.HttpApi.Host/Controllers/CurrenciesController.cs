global using Wajba.Dtos.CurrenciesContract;

namespace Wajba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : AbpController
    {
        private readonly ICurrenciesAppService _currenciesAppService;

        public CurrenciesController(ICurrenciesAppService currenciesAppService)
        {
            _currenciesAppService = currenciesAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<CurrenciesDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _currenciesAppService.GetListAsync(input);
        }

        [HttpGet("{id}")]
        public async Task<CurrenciesDto> GetAsync(int id)
        {
            return await _currenciesAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<CurrenciesDto> CreateAsync(CreateUpdateCurrenciesDto input)
        {
            return await _currenciesAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<CurrenciesDto> UpdateAsync(int id, CreateUpdateCurrenciesDto input)
        {
            return await _currenciesAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _currenciesAppService.DeleteAsync(id);
        }
    }
}