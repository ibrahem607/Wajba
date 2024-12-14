global using Wajba.Dtos.ItemTaxContract;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemTaxController : AbpController
{
    private readonly IItemTaxAppService _itemTaxAppService;

    public ItemTaxController(IItemTaxAppService itemTaxAppService)
    {
        _itemTaxAppService = itemTaxAppService;
    }

    [HttpGet]
    public async Task<PagedResultDto<ItemTaxDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
    {
        return await _itemTaxAppService.GetListAsync(input);
    }

    [HttpGet("{id}")]
    public async Task<ItemTaxDto> GetAsync(int id)
    {
        return await _itemTaxAppService.GetAsync(id);
    }

    [HttpPost]
    public async Task<ItemTaxDto> CreateAsync(CreateUpdateItemTaxDto input)
    {
        return await _itemTaxAppService.CreateAsync(input);
    }

    [HttpPut("{id}")]
    public async Task<ItemTaxDto> UpdateAsync(int id, CreateUpdateItemTaxDto input)
    {
        return await _itemTaxAppService.UpdateAsync(id, input);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(int id)
    {
        await _itemTaxAppService.DeleteAsync(id);
    }
}