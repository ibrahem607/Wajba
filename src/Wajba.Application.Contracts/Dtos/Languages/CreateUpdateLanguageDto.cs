namespace Wajba.Dtos.Languages;

public class CreateUpdateLanguageDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public IFormFile Image { get; set; } // File input for the image
    public Status Status { get; set; }
}
