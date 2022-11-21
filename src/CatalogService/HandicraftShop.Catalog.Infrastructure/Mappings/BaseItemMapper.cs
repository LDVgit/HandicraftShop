namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

/// <summary>
/// 
/// </summary>
public abstract class BaseItemMapper<TItem> : IDataMapper
    where TItem : EntityId<Guid>
{
    public void RegisterCLassMap()
    {
        BsonClassMap.RegisterClassMap<TItem>(
            map =>
            {
                map.AutoMap();
                map.MapProperty(x => x.Id).SetSerializer(new GuidSerializer(BsonType.String));
                ChangeAutoMap(map);
            });
    }

    protected abstract void ChangeAutoMap(BsonClassMap<TItem> map);
}