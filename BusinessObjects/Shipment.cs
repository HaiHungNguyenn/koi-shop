using BusinessObjects.Enum;

namespace BusinessObjects;

public class Shipment
{
    public Guid Id { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public DateTime ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }
    public ShippingStatus Status { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}