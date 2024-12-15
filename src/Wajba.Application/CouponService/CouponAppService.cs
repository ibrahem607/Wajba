global using Wajba.Models.CouponsDomain;
global using Wajba.Dtos.CouponContract;

namespace Wajba.CouponService;

[RemoteService(false)]
public class CouponAppService : ApplicationService
{
    private readonly IRepository<Coupon, int> _couponRepository;
    private readonly IImageService _imageService;

    public CouponAppService(IRepository<Coupon, int> couponRepository, IImageService imageService)
    {
        _couponRepository = couponRepository;
        _imageService = imageService;
    }

    public async Task<CouponDto> CreateAsync(CreateUpdateCouponDto input)
    {
        var imageUrl = input.Image != null
            ? await _imageService.UploadAsync(input.Image)
            : null;

        var coupon = ObjectMapper.Map<CreateUpdateCouponDto, Coupon>(input);
        coupon.ImageUrl = imageUrl;

        await _couponRepository.InsertAsync(coupon);
        return ObjectMapper.Map<Coupon, CouponDto>(coupon);
    }
    // Read (Get by ID)
    public async Task<CouponDto> GetAsync(int id)
    {
        var coupon = await _couponRepository.GetAsync(id);
        return ObjectMapper.Map<Coupon, CouponDto>(coupon);
    }

    // Read (Get List)
    public async Task<PagedResultDto<CouponDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var query = await _couponRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting
        );

        var totalCount = await _couponRepository.CountAsync();
        return new PagedResultDto<CouponDto>(
            totalCount,
            ObjectMapper.Map<List<Coupon>, List<CouponDto>>(query)
        );
    }
    public async Task<CouponDto> UpdateAsync(int id, CreateUpdateCouponDto input)
    {
        var coupon = await _couponRepository.GetAsync(id);

        if (input.Image != null)
        {
            //if (!string.IsNullOrEmpty(coupon.ImageUrl))
            //{
            //    await _imageService.DeleteImageAsync(coupon.ImageUrl);
            //}

            coupon.ImageUrl = await _imageService.UploadAsync(input.Image);
        }

        ObjectMapper.Map(input, coupon);

        await _couponRepository.UpdateAsync(coupon);
        return ObjectMapper.Map<Coupon, CouponDto>(coupon);
    }

    public async Task DeleteAsync(int id)
    {
        //var coupon = await _couponRepository.GetAsync(id);

        //if (!string.IsNullOrEmpty(coupon.ImageUrl))
        //{
        //    await _imageService.DeleteImageAsync(coupon.ImageUrl);
        //}

        await _couponRepository.DeleteAsync(id);
    }
}