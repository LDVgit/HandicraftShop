namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

/// <summary>
/// CategoryType Map for MongoDb
/// </summary>
public class CategoryTypeMapper : BaseItemMapper<CategoryType>
{
    protected override void ChangeAutoMap(BsonClassMap<CategoryType> map)
    {
    }
}