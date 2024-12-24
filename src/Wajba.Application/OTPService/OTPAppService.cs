namespace Wajba.OTPService;

[RemoteService(false)]
public class OTPAppService :ApplicationService
{
    private readonly IRepository<OTP, int> _repository;

    public OTPAppService(IRepository<OTP, int> repository)
    {
     _repository = repository;
    }
    public async Task<OTPDto> CreateAsync(CreateUpdateOTPDto input)
    {
        OTP oTP = new OTP
        {
            DigitLimit = input.DigitLimit,
            ExpiryTimeInMinutes = input.ExpiryTimeInMinutes,
            Type = input.Type,
        };
        OTP oTP1 = await _repository.InsertAsync(oTP, true);
        return ObjectMapper.Map<OTP, OTPDto>(oTP1);
    }
    public async Task<OTPDto> UpdateAsync(int id, CreateUpdateOTPDto input)
    {
        OTP oTP = await _repository.GetAsync(id);
        oTP.ExpiryTimeInMinutes = input.ExpiryTimeInMinutes;
        oTP.Type = input.Type;
        oTP.DigitLimit = input.DigitLimit;
        oTP.LastModificationTime = DateTime.UtcNow;
        OTP oTP1 = await _repository.UpdateAsync(oTP, true);
        return ObjectMapper.Map<OTP, OTPDto>(oTP1);
    }

    public async Task<PagedResultDto<OTPDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        IQueryable<OTP> queryable = await _repository.GetQueryableAsync();
        int totalCount = await AsyncExecuter.CountAsync(queryable);
        List<OTP> otpss = await AsyncExecuter.ToListAsync(queryable
            .OrderBy(input.Sorting ?? nameof(OTP.DigitLimit))
            .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<OTPDto>(
            totalCount,
            ObjectMapper.Map<List<OTP>, List<OTPDto>>(otpss)
        );
    }
    public async Task<OTPDto> GetByIdAsync(int id)
    {
        OTP oTP1 = await _repository.GetAsync(id);
        return ObjectMapper.Map<OTP, OTPDto>(oTP1);
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}