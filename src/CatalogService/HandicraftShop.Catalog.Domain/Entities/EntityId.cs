namespace HandicraftShop.Catalog.Domain.Entities;

/// <summary> Persistent Entity - Mascot </summary>
public abstract class EntityId<T>
{
    /// <summary> Identifier </summary>
    public T Id { get; set; } = default!;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset DeleteDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
}