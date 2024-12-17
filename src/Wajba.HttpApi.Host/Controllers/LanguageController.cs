global using Wajba.Languages;
global using Wajba.Dtos.Languages;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : AbpController
{
    private readonly LanguageAppService _languageAppService;

    public LanguageController(LanguageAppService languageAppService)
    {
        _languageAppService = languageAppService;
    }

    [HttpGet]
    public async Task<PagedResultDto<LanguageDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
    {
        return await _languageAppService.GetListAsync(input);
    }

    [HttpGet("{id}")]
    public async Task<LanguageDto> GetAsync(int id)
    {
        return await _languageAppService.GetAsync(id);
    }

    [HttpPost]
    public async Task<LanguageDto> CreateAsync([FromForm] CreateUpdateLanguageDto input)
    {
        return await _languageAppService.CreateAsync(input);
    }

    [HttpPut("{id}")]
    public async Task<LanguageDto> UpdateAsync(int id, [FromForm] CreateUpdateLanguageDto input)
    {
        return await _languageAppService.UpdateAsync(id, input);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(int id)
    {
        await _languageAppService.DeleteAsync(id);
    }
}