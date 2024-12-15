namespace Wajba.Dtos.ThemesContract;

public class ThemesDto:EntityDto<int>
{
    public int Id { get; set; }
    public string LogoUrl { get; set; }
    public string BrowserTabIconUrl { get; set; }
    public string FooterLogoUrl { get; set; }
}
