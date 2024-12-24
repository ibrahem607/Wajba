global using Wajba.Dtos.CurrenciesContract;
using Wajba.Categories;
using Wajba.CurrenciesService;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : AbpController
{
    private readonly CurrenciesAppService _currenciesAppService;

    public CurrenciesController(CurrenciesAppService currenciesAppService)
    {
        _currenciesAppService = currenciesAppService;
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] GetinputCurrency input)
    {
        try
        {
            var pagedResultDto= await _currenciesAppService.GetListAsync(input);

            return Ok(new ApiResponse<PagedResultDto<CurrenciesDto>>
            {
                Success = true,
                Message = "currencies retrieved successfully.",
                Data = pagedResultDto
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving currencies: {ex.Message}",
                Data = null
            });
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            CurrenciesDto currenciesDto = await _currenciesAppService.GetByIdAsync(id);

            return Ok(new ApiResponse<CurrenciesDto>
            {
                Success = true,
                Message = "Currency retrieved successfully.",
                Data = currenciesDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Currency not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving Currency: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUpdateCurrenciesDto input)
    {
        try
        {
            await _currenciesAppService.CreateAsync(input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Currency created successfully.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error creating Currency: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateUpdateCurrenciesDto input)
    {
        try
        {
            CurrenciesDto currencies = await _currenciesAppService.UpdateAsync(id, input);
            return Ok(new ApiResponse<CurrenciesDto>
            {
                Success = true,
                Message = "Currency updated successfully.",
                Data = currencies
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Currency not found.",
                Data = null
            });
        }

    }
    [HttpDelete("{id}")]
    public async Task DeleteAsync(int id)
    {
        await _currenciesAppService.DeleteAsync(id);
    }
}