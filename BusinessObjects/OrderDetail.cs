namespace BusinessObjects;

public class OrderDetail
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}