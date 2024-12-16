namespace Wajba.Dtos.SitesContact;

public class GetSiteInput: PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
