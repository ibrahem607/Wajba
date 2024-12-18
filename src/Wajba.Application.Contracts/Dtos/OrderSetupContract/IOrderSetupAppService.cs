using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Dtos.OrderSetupContract
{
    public interface IOrderSetupAppService
    {
        Task<OrderSetupDto> GetAsync(int id);
        Task<List<OrderSetupDto>> GetAllAsync();
        Task<OrderSetupDto> CreateAsync(CreateUpdateOrderSetupDto input);
        Task<OrderSetupDto> UpdateAsync(int id, CreateUpdateOrderSetupDto input);
        Task DeleteAsync(int id);
    }
}
