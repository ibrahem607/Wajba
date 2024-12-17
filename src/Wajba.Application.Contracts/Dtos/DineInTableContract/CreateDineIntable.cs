namespace Wajba.Dtos.DineInTableContract;

public class CreateDineIntable
{
    [Required]
    public string Name { get; set; }
    [Required]
    public byte Size { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public int BranchId { get; set; }
}
