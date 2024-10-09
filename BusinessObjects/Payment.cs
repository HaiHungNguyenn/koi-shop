using BusinessObjects.Enum;

namespace BusinessObjects;

public class Payment
{
    public Guid Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}