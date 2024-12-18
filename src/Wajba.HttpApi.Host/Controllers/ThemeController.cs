﻿global using Wajba.ThemesService;
global using Wajba.Dtos.ThemesContract;

namespace Wajba.Controllers;

[IgnoreAntiforgeryToken]
public class ThemeController : WajbaController
{
    private readonly ThemesAppservice _themesAppservice;

    public ThemeController(ThemesAppservice themesAppservice)
    {
       _themesAppservice = themesAppservice;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateThemesDto input)
    {
        try
        {
            await _themesAppservice.CreateAsync(input);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Theme created successfully.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error creating theme: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateThemesDto input)
    {
        try
        {
            ThemesDto themesDto = await _themesAppservice.UpdateAsync(id, input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "THeme updated successfully.",
                Data = themesDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Theme not found.",
                Data = null
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            ThemesDto themesDto = await _themesAppservice.GetByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "themes retrieved successfully.",
                Data = themesDto
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "themes not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving themes: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] GetThemeInput input)
    {
        try
        {
            var themes = await _themesAppservice.GetListAsync(input);
            return Ok(new ApiResponse<PagedResultDto<ThemesDto>>
            {
                Success = true,
                Message = "themes retrieved successfully.",
                Data = themes
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error retrieving themes: {ex.Message}",
                Data = null
            });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _themesAppservice.DeleteAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Theme deleted successfully.",
                Data = null
            });
        }
        catch (EntityNotFoundException)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Theme not found.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error deleting theme: {ex.Message}",
                Data = null
            });
        }
    }

}
