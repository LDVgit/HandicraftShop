namespace HandicraftShop.Catalog.Domain.Entities;

/// <summary> Persistent Entity - CategoryType </summary>
public class CategoryType : EntityId<Guid>
{
    public string Name { get; set; } = null!;
    public Category Category { get; set; } = null!;
}