namespace BusinessObjects;

public class KoiCategory
{
    public Guid Id { get; set; }
    public string Origin { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}