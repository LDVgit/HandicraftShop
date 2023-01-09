namespace HandicraftShop.Catalog.DataAccess.Interfaces;

using HandicraftShop.Catalog.DataAccess.Interfaces.Repositories;
using HandicraftShop.Catalog.Domain.Entities;

/// <summary> Database context. </summary>
public interface IDbProvider
{
    //Add in trnsaction method;

    Task CreateTable(string name, string collation);
    Task DeleteTable(string name);
    Task CreateIndex<T>(IRepository<T> repository, OrderBuilder<T> orderBuilder, string indexName, bool unique = false) where T : EntityId<Guid>;
    Task DeleteIndex<T>(IRepository<T> repository, string indexName) where T : EntityId<Guid>;
}