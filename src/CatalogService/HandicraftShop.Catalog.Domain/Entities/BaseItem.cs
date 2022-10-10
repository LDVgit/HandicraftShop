namespace HandicraftShop.Catalog.Domain.Entities;

using Interfaces.Entities;

public class BaseItem : EntityId<Guid>, IItem
{
    public string VendorCode { get; set; }
    public string Name { get; set; }
    public Guid? MainImageId { get; set; }
    public Image MainImage { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public ICollection<Image> Images { get; set; }
}