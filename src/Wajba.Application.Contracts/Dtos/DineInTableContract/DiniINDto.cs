namespace Wajba.Dtos.DineInTableContract;

public class DiniINDto:EntityDto<int>
{
    public string Name { get; set; }
    public byte Size { get; set; }
    public bool IsActive { get; set; }
    public int BranchId { get; set; }
}
