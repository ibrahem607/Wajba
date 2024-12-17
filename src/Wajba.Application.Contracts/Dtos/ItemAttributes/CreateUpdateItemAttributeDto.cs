namespace Wajba.Dtos.ItemAttributes;

public class CreateUpdateItemAttributeDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Status Status { get; set; }
}
