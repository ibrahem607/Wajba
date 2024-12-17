namespace Wajba.Dtos.CouponContract;

public class GetCouponsInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }
    public int Code { get; set; }
    public decimal? Discount { get; set; }
    public int? DisCountType { get; set; }
    public  string? StartDate { get; set; }
    public string? EndDate { get; set; }
    

}
