namespace Wajba.Dtos.FaqsContract;

public class FaqDto : EntityDto<int>
{
    public string Question { get; set; }
    public string Answer { get; set; }
}
