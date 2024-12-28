global using Wajba.Dtos.OTPContract;
global using Wajba.OTPService;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OTPController : WajbaController
{
    private readonly OTPAppService _oTPAppService;

    public OTPController(OTPAppService oTPAppService)
    {
        _oTPAppService = oTPAppService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateUpdateOTPDto input)
    {
        try
        {
            await _oTPAppService.CreateAsync(input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "OTP created successfully.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error creating otp: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateUpdateOTPDto input)
    {
        try
        {
            OTPDto oTPDto = await _oTPAppService.UpdateAsync(id, input);
            return Ok(new ApiResponse<OTPDto>
            {
                Success = true,
                Message = "Otp updated successfully.",
                Data = oTPDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Otp not found.",
                Data = null
            });
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            OTPDto oTPDto = await _oTPAppService.GetByIdAsync(id);
            return Ok(new ApiResponse<OTPDto>
            {
                Success = true,
                Message = "OTp retrieved successfully.",
                Data = oTPDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Otp not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving otp: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
    {
        try
        {
            var dto = await _oTPAppService.GetListAsync(input);
            return Ok(new ApiResponse<PagedResultDto<OTPDto>>
            {
                Success = true,
                Message = "Otps retrieved successfully.",
                Data = dto
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving otps: {ex.Message}",
                Data = null
            });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _oTPAppService.DeleteAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Otp deleted successfully.",
                Data = null
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Otp not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error deleting otp: {ex.Message}",
                Data = null
            });
        }
    }
}