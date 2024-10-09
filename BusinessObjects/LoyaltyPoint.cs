namespace BusinessObjects;

public class LoyaltyPoint
{
    public Guid Id { get; set; }
    public int EarnedPoint { get; set; }
    public int UsedPoint { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}