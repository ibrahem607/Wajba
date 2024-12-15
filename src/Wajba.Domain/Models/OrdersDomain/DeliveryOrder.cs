namespace Wajba.Models.OrdersDomain;

public class DeliveryOrder : FullAuditedEntity<int>
{
    public string Title { get; set; }

    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime ApproximateTime { get; set; }
    public string? DeliveryBoyId { get; set; }  // Foreign key to DeliveryBoy
    public virtual AppUser? DeliveryBoy { get; set; }
    public int? OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public DeliveryOrder()
    {

    }
}