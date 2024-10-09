namespace BusinessObjects;

public class CartItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public Guid CartId { get; set; }
    public Guid KoiFishId { get; set; }
    public virtual Cart Cart { get; set; } = null!;
    public virtual KoiFish Fish { get; set; } = null!;
}