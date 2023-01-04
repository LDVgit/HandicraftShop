namespace HandicraftShop.Catalog.Infrastructure.DataAccess.Repositories;

using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Entities;
using HandicraftShop.Catalog.Domain.Interfaces.Repositories;
using MongoDB.Driver;

/// <summary> Implementation IRepository for MongoDb. </summary>
public class MongoRepository<T> : IRepository<T> where T : EntityId<Guid>
{
    /// <summary> Mongo Database </summary>
    private IMongoDatabase _database;

    /// <summary> Gets the collection </summary>
    private IMongoCollection<T> _collection;

    /// <summary>
    /// Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Entity</returns>
    /// <remarks>
    /// LowLevelFunc without awaiting. Use it with await! 
    /// </remarks>
    public Task<T> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return _collection.Find(e => e.Id == id).SingleOrDefaultAsync(ct);
    }

    /// <summary>
    /// Get all entities in collection
    /// </summary>
    /// <returns>Collection of entities</returns>
    /// <param name="ct">CancellationToken</param>
    public Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return _collection.Find(_ => true).ToListAsync(ct);
    }

    /// <summary>
    /// Async Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="ct">CancellationToken</param>
    public virtual async Task<T> InsertAsync(T entity, CancellationToken ct)
    {
        await _collection.InsertOneAsync(entity, null, ct);
        return entity;
    }

    /// <summary>
    /// Async Insert many entities
    /// </summary>
    /// <param name="entities">Entities</param>
    /// <param name="ct">CancellationToken</param>
    public virtual async Task InsertManyAsync(IEnumerable<T> entities, CancellationToken ct)
    {
        await _collection.InsertManyAsync(entities, null, ct);
    }

    /// <summary>
    /// Async Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    /// <param name="ct">CancellationToken</param>
    /// <returns>Collection of entities</returns>
    public virtual async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities, CancellationToken ct)
    {
        await _collection.InsertManyAsync(entities, null, ct);
        return entities;
    }

    /// <summary>
    /// Async Update entity
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="ct">CancellationToken</param>
    public virtual async Task<T> UpdateAsync(T entity, CancellationToken ct = default(CancellationToken))
    {
        await _collection.ReplaceOneAsync(
            x => x.Id == entity.Id,
            entity,
            new ReplaceOptions() { IsUpsert = false },
            ct);
        return entity;
    }

    /// <summary>
    /// Updates a single entity.
    /// </summary>
    /// <param name="filterexpression"></param>
    /// <param name="updateBuilder"></param>
    /// <returns></returns>
    public async Task UpdateOneAsync(Expression<Func<T, bool>> filterexpression, UpdateBuilder<T> updateBuilder)
    {           
        var update = Builders<T>.Update.Combine(updateBuilder.Fields);
        await _collection.UpdateOneAsync(filterexpression, update);
    }

    /// <summary>
    /// Update field for entity
    /// </summary>
    /// <typeparam name="TU">Value</typeparam>
    /// <param name="id">Ident record</param>
    /// <param name="expression">Linq Expression</param>
    /// <param name="value">value</param>
    public async Task UpdateField<TU>(Guid id, Expression<Func<T, TU>> expression, TU value)
    {
        var builder = Builders<T>.Filter;
        var filter = builder.Eq(x => x.Id, id);
        var update = Builders<T>.Update
            .Set(expression, value);

        await _collection.UpdateOneAsync(filter, update);
    }
}