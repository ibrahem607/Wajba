global using Wajba.Dtos.TimeSlotsContract;
global using Wajba.TimeSlotsServices;

namespace Wajba.Controllers;

public class TimeSlotController : WajbaController
{
    private readonly TimeSlotsAppservice _timeSlotsServices;

    public TimeSlotController(TimeSlotsAppservice timeSlotsServices)
    {
      _timeSlotsServices = timeSlotsServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateTimeSlotDot input)
    {
        try
        {
            await _timeSlotsServices.CreateAsync(input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "TimeSlot created successfully.",
                Data = input
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error creating timeslot: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateTimeSlotDot input)
    {
        try
        {
            TimeSlotDto timeSlotDto= await _timeSlotsServices.UpdateAsync(id, input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "timeslot updated successfully.",
                Data = timeSlotDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "timeslot not found.",
                Data = null
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            TimeSlotDto timeSlot = await _timeSlotsServices.GetByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "timeslot retrieved successfully.",
                Data = timeSlot
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "timeslot not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving timeslot: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] GetTimeSlotInput input)
    {
        try
        {
            var pagedResultDto = await _timeSlotsServices.GetListAsync(input);
            return Ok(new ApiResponse<PagedResultDto<TimeSlotDto>>
            {
                Success = true,
                Message = "timeslots retrieved successfully.",
                Data = pagedResultDto
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving timeslot: {ex.Message}",
                Data = null
            });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _timeSlotsServices.DeleteAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "timeslot deleted successfully.",
                Data = null
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "timeslot not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error deleting timeslot: {ex.Message}",
                Data = null
            });
        }
    }

}
