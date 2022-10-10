namespace HandicraftShop.Catalog.Domain.Dto;

/// <summary> Persistent Entity - Mascot </summary>
public class ImageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string Extension { get; set; }
}