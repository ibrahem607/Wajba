namespace Wajba.Mapping;

public class ThemMapping : Profile
{
    public ThemMapping()
    {
        CreateMap<Theme, ThemesDto>();
        CreateMap<CreateThemesDto, Theme>().ForMember(c => c.BrowserTabIconUrl, opt => opt.Ignore())
            .ForMember(p => p.FooterLogoUrl, p => p.Ignore())
            .ForMember(p => p.LogoUrl, p => p.Ignore());
    }
}
