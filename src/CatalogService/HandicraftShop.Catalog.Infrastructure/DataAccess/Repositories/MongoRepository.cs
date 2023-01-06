namespace HandicraftShop.Catalog.Infrastructure.DataAccess.Repositories;

using System.Linq.Expressions;
using Domain.Entities;
using HandicraftShop.Catalog.DataAccess;
using HandicraftShop.Catalog.DataAccess.Repositories;
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
    public Task<T> GetByIdAsync(Guid id, CancellationToken ct = default(CancellationToken))
    {
        return _collection.Find(e => e.Id == id).SingleOrDefaultAsync(ct);
    }

    /// <summary>
    /// Get all entities in collection
    /// </summary>
    /// <returns>Collection of entities</returns>
    /// <param name="ct">CancellationToken</param>
    public Task<List<T>> GetAllAsync(CancellationToken ct = default(CancellationToken))
    {
        return _collection.Find(_ => true).ToListAsync(ct);
    }

    /// <summary>
    /// Async Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="ct">CancellationToken</param>
    public virtual async Task<T> InsertAsync(T entity, CancellationToken ct = default(CancellationToken))
    {
        await _collection.InsertOneAsync(entity, null, ct);
        return entity;
    }

    /// <summary>
    /// Async Insert many entities
    /// </summary>
    /// <param name="entities">Entities</param>
    /// <param name="ct">CancellationToken</param>
    public virtual async Task InsertManyAsync(IEnumerable<T> entities, CancellationToken ct = default(CancellationToken))
    {
        await _collection.InsertManyAsync(entities, null, ct);
    }

    /// <summary>
    /// Async Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    /// <param name="ct">CancellationToken</param>
    /// <returns>Collection of entities</returns>
    public virtual async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities, CancellationToken ct = default(CancellationToken))
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
    /// <param name="filterexpression"> Filter for selection entity. Filter like where from linq </param>
    /// <param name="updateBuilder"> Update params. </param>
    /// <param name="ct">CancellationToken</param>
    /// <returns></returns>
    public async Task UpdateOneAsync(Expression<Func<T, bool>> filterexpression, UpdateBuilder<T> updateBuilder, CancellationToken ct = default(CancellationToken))
    {           
        var update = Builders<T>.Update.Combine(updateBuilder.Fields);
        await _collection.UpdateOneAsync(filterexpression, update, null, ct);
    }

    /// <summary>
    /// Update field for entity
    /// </summary>
    /// <typeparam name="TU">Value</typeparam>
    /// <param name="id">Ident record</param>
    /// <param name="expression">Linq Expression</param>
    /// <param name="value">value</param>
    /// <param name="ct">CancellationToken</param>
    public async Task UpdateField<TU>(Guid id, Expression<Func<T, TU>> expression, TU value, CancellationToken ct = default(CancellationToken))
    {
        var builder = Builders<T>.Filter;
        var filter = builder.Eq(x => x.Id, id);
        var update = Builders<T>.Update
            .Set(expression, value);

        await _collection.UpdateOneAsync(filter, update, null, ct);
    }

    /// <summary>
    /// Updates a many entities by expression.
    /// </summary>
    /// <param name="filterexpression">Filter like where from linq</param>
    /// <param name="updateBuilder"> Update params. </param>
    /// <param name="ct">CancellationToken</param>
    /// <returns></returns>
    public async Task UpdateManyAsync(Expression<Func<T, bool>> filterexpression, UpdateBuilder<T> updateBuilder, CancellationToken ct = default(CancellationToken))
    {
        var update = Builders<T>.Update.Combine(updateBuilder.Fields);
        await _collection.UpdateManyAsync(filterexpression, update, null, ct);
    }

    /// <summary>
    /// Async Delete entity
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="ct">CancellationToken</param>
    public async Task<T> DeleteAsync(T entity, CancellationToken ct = default(CancellationToken))
    {
        await _collection.DeleteOneAsync(e => e.Id == entity.Id, ct);
        return entity;
    }
}