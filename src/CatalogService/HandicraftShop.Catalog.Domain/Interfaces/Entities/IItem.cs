namespace HandicraftShop.Catalog.Domain.Interfaces.Entities;

using Domain.Entities;

public interface IItem : IBaseEntity
{
    string VendorCode { get; set; }
    string Name { get; set; }
    Guid? MainImageId { get; set; }
    Image MainImage { get; set; }
    decimal Price { get; set; }
    decimal? OldPrice { get; set; }
    string Description { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    ICollection<Image> Images { get; set; }
}