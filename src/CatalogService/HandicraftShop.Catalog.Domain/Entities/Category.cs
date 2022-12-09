namespace HandicraftShop.Catalog.Domain.Entities;

/// <summary> Persistent Entity - Category </summary>
public class Category : EntityId<Guid>
{
    public Category? Parent { get; set; } = null;
    public LinkedList<Category> Children { get; set; } = new();
    public string Name { get; set; } = null!;
    private bool IsRoot { get; set; }
    bool IsLeaf { get; set; }
    int Level { get; set; }
}