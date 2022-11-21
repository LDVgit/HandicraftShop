namespace HandicraftShop.Catalog.Domain.Entities;

/// <summary> Persistent Entity - Mascot </summary>
public class Image : EntityId<Guid>
{
    public string Name { get; set; } = null!;
    public int Size { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string Extension { get; set; } = null!;
    public bool IsUsedForMain { get; set; }
}