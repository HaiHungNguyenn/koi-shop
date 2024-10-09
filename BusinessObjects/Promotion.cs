using BusinessObjects.Enum;

namespace BusinessObjects;

public class Promotion
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public string Code { get;set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PromotionType Type { get; set; }
    public decimal PromotionValue { get; set; }
    public decimal? MinPurchase { get; set; }
    public PromotionStatus Status { get; set; }
    public virtual ICollection<OrderPromotion> OrderPromotions { get;set; } = new List<OrderPromotion>();
}
