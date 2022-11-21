namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

/// <summary>
/// 
/// </summary>
public class MascotMapper : BaseItemMapper<Mascot>
{
    protected override void ChangeAutoMap(BsonClassMap<Mascot> map)
    {
    }
}