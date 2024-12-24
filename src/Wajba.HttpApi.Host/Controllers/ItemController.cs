global using Wajba.ItemServices;
global using Wajba.Dtos.ItemsDtos;
using Wajba.Categories;

namespace Wajba.Controllers;

public class ItemController : WajbaController
{
    private readonly ItemAppServices _itemAppServices;

    public ItemController(ItemAppServices itemAppServices)
    {
       _itemAppServices = itemAppServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateItemDto input)
    {
        try
        {
            await _itemAppServices.CreateAsync(input);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Item created successfully.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = $"Error creating item: {ex.Message}",
                Data = null
            });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateItemDto input)
    {
        try
        {
            var updatedcategory = await _itemAppServices.UpdateAsync(id, input);
            return Ok(new ApiResponse<CategoryDto>
            {
                Success = true,
                Message = "Category updated successfully.",
                Data = updatedcategory
            });
        }
        catch (EntityNotFoundException)
        {
            // If the category is not found, return a 404 Not Found response
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Category not found.",
                Data = null
            });
        }

    }

}
