namespace Wajba.Dtos.ThemesContract;

public class GetThemeInput: PagedAndSortedResultRequestDto
{
    public string? Filter {  get; set; }
}
