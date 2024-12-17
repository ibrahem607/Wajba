namespace Wajba.Dtos.FaqsContract;

public class CreateFaqs
{
    [Required]
    public string Question { get; set; }
    [Required]
    public string Answer { get; set; }
}
