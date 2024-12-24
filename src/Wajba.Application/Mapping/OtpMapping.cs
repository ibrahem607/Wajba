global using Wajba.Dtos.OTPContract;
global using Wajba.Models.OTPDomain;

namespace Wajba.Mapping;

public class OtpMapping : Profile
{
    public OtpMapping()
    {
        CreateMap<OTP, OTPDto>().ForMember(p => p.ExpiryTimeInMinutes, o => o.MapFrom(p => p.ExpiryTimeInMinutes))
                .ForMember(p => p.DigitLimit, o => o.MapFrom(p => p.DigitLimit))
                .ForMember(p => p.Type, o => o.MapFrom(p => p.Type));
    }
}
