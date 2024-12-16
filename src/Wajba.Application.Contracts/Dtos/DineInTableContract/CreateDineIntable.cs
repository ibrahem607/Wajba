namespace Wajba.Dtos.DineInTableContract;

public class CreateDineIntable
{
    public string Name { get; set; }
    public byte Size { get; set; }
    public bool IsActive { get; set; }
    public int BranchId { get; set; }
}
