using BusinessObjects.Enum;

namespace BusinessObjects;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string? Note { get; set; }
    public decimal? Discount { get; set; }
    public decimal ShippingCost { get; set; }

    public Guid UserId { get; set; }
    public Guid ShipmentId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Shipment Shipment { get; set; } = null!;
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<OrderPromotion> OrderPromotions { get; set; } = new List<OrderPromotion>();
}