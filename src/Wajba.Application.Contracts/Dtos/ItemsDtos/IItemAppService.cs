using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Dtos.ItemsDtos
{
    public interface IItemAppService
    {
        Task<ItemDto> GetByIdAsync(int id);
        Task<List<ItemDto>> GetAllAsync();
        Task<ItemDto> CreateAsync(CreateItemDto input);
        Task<ItemDto> UpdateAsync(int id, UpdateItemDTO input);
        Task DeleteAsync(int id);
    }
}
