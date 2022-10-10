namespace HandicraftShop.Catalog.Domain.Dto;

/// <summary>
///     Get Dto - Base for Item
/// </summary>
public class BaseItemDto
{
    public Guid Id { get; set; }
    public string VendorCode { get; set; }
    public string Name { get; set; }
    public Guid MainImageId { get; set; }
    public ImageDto MainImage { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public ICollection<ImageDto> Images { get; set; }
}