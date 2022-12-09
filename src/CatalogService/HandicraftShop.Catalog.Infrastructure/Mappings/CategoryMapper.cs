namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

/// <summary>
/// Category Map for MongoDb
/// </summary>
public class CategoryMapper : BaseItemMapper<Category>
{
    protected override void ChangeAutoMap(BsonClassMap<Category> map)
    {
    }
}