using System.Collections;

namespace BusinessObjects;

public class KoiFish
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public string? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Weight { get; set; }
    public decimal Size { get; set; }
    public string? Personality { get; set; }
    
    public Guid KoiPackageId { get; set; }
    public Guid KoiCategoryId { get; set; }
    public virtual KoiPackage KoiPackage { get; set; } = null!;
    public virtual KoiCategory KoiCategory { get; set; } = null!;
    public virtual ICollection<KoiImage> KoiImages { get; set; } = new List<KoiImage>();
}