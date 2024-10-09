namespace BusinessObjects;

public class KoiPackage
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PriceEachFish { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsSoldOut { get; set; }
    
    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}