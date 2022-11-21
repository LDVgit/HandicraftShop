namespace HandicraftShop.Catalog.Domain.Entities;

using Interfaces.Entities;

public class BaseItem : EntityId<Guid>, IItem
{
    public BaseItem()
    {
        Id = Guid.NewGuid();
    }

    public string VendorCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public Guid? MainImageId { get; set; }
    public Image MainImage { get; set; } = null!;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string Description { get; set; } = null!;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset DeleteDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public bool Deleted { get; set; }

    public ICollection<Image> Images { get; set; } = new List<Image>();
}