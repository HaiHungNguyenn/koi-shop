using BusinessObjects.Enum;

namespace BusinessObjects;

public class Cart
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public CartStatus Status { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}