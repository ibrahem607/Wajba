namespace Wajba.Dtos.ItemsDtos;

public class GetItemInput : PagedAndSortedResultRequestDto
{
    public string? name { get; set; }
    public int? BranchId { get; set; }
}
