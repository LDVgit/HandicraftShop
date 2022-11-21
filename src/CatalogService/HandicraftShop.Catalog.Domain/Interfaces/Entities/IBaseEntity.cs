namespace HandicraftShop.Catalog.Domain.Interfaces.Entities;

public interface IBaseEntity
{
    Guid Id { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset DeleteDate { get; set; }
    public bool Deleted { get; set; }
}