namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

/// <summary>
/// ImageMap for MongoDb
/// </summary>
public class ImageMapper : BaseItemMapper<Image>
{
    protected override void ChangeAutoMap(BsonClassMap<Image> map)
    {
    }
}