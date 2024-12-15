using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wajba.OffersContract
{
    public interface IOfferService 
    {
        Task<OfferDto> GetAsync(int id);
        Task<List<OfferDto>> GetAllAsync();
        Task<OfferDto> CreateAsync(CreateUpdateOfferDto input);
        Task<OfferDto> UpdateAsync(int id, CreateUpdateOfferDto input);
        Task DeleteAsync(int id);
    }
}
