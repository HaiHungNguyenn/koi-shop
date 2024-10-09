namespace BusinessObjects;

public class OrderPromotion
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid PromotionId { get; set; }
    public DateTime UsedDate { get; set; }
    public virtual Order Order { get; set; } = null!;
    public virtual Promotion Promotion { get; set; } = null!;
}