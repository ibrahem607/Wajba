using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Wajba.CouponContract;
using Wajba.CouponService;

namespace Wajba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : AbpController
    {
        private readonly CouponAppService _couponAppService;

        public CouponController(CouponAppService couponAppService)
        {
            _couponAppService = couponAppService;
        }

        [HttpPost]
        public async Task<CouponDto> CreateAsync([FromForm] CreateUpdateCouponDto input)
        {
            return await _couponAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<CouponDto> UpdateAsync(int id, [FromForm] CreateUpdateCouponDto input)
        {
            return await _couponAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _couponAppService.DeleteAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<CouponDto> GetAsync(int id)
        {
            return await _couponAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CouponDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _couponAppService.GetListAsync(input);
        }
    }
}