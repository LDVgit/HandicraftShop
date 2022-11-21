namespace HandicraftShop.Catalog.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DbFieldNameAttribute : Attribute
{
    public DbFieldNameAttribute(string name)
    {
        Name = name;
    }
    public virtual string Name { get; }
}