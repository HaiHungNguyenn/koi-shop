namespace BusinessObjects;

public class KoiImage
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    
    public Guid KoiFishId { get; set; }
    public virtual KoiFish Fish { get; set; } = null!;
}