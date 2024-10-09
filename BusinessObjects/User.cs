using System.Collections;

namespace BusinessObjects;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } 
    public string? Address { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
    public virtual ICollection<LoyaltyPoint> LoyaltyPoints { get; set; } = new List<LoyaltyPoint>();
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
