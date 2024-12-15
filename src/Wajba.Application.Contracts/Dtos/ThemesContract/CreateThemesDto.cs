namespace Wajba.Dtos.ThemesContract;
public class CreateThemesDto
{
    public IFormFile LogoUrl { get; set; }
    public IFormFile BrowserTabIconUrl { get; set; }
    public IFormFile FooterLogoUrl { get; set; }
}
