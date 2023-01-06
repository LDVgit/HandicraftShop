namespace HandicraftShop.Catalog.Infrastructure.Mappings;

using HandicraftShop.Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

/// <summary> Base mapper class </summary>
public abstract class BaseItemMapper<TItem> : IDataMapper
    where TItem : EntityId<Guid>
{
    /// <summary>
    /// Registration call.
    /// </summary>
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

    /// <summary>
    /// Change entity property name 
    /// </summary>
    protected abstract void ChangeAutoMap(BsonClassMap<TItem> map);
}