namespace HandicraftShop.Catalog.Domain.Entities;

/// <summary> Persistent Entity - Mascot </summary>
public class EntityId<T>
{
    /// <summary> Identifier </summary>
    public T Id { get; set; } = default!;
}