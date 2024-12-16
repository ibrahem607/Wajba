namespace Wajba.Models.FaqsDomain;

public class FAQs : FullAuditedEntity<int>
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public FAQs()
    {

    }
}