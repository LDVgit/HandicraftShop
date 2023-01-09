namespace HandicraftShop.Catalog.DataAccess.Interfaces;

using System.Linq.Expressions;
using MongoDB.Driver;

/// <summary> Using for update some property in entity. </summary>
/// <typeparam name="T"> Entity type. </typeparam>
public class UpdateBuilder<T>
{
    /// <summary> Update property list for MongoDb. </summary>
    private readonly List<UpdateDefinition<T>> _list = new();

    /// <summary> Update property list for database. </summary>
    private readonly List<ExpressionFieldDefinition<T, object>> _expressionFieldDefinitions = new();

    protected UpdateBuilder() { }

    public static UpdateBuilder<T> Create()
    {
        return new();
    }

    /// <summary>
    /// Set new value to entity property
    /// </summary>
    /// <param name="selector"> Property selector. </param>
    /// <param name="value"> New value. </param>
    /// <typeparam name="TProperty"> Property type. </typeparam>
    /// <returns></returns>
    public UpdateBuilder<T> Set<TProperty>(Expression<Func<T, TProperty>> selector, TProperty value)
    {
        //for mongodb
        _list.Add(Builders<T>.Update.Set(selector, value));

        //for other Db
        _expressionFieldDefinitions.Add(new ExpressionFieldDefinition<T, object>(selector, value));

        return this;
    }

    /// <summary>
    /// Call in repository for MongoDb
    /// </summary>
    public IEnumerable<UpdateDefinition<T>> Fields {
        get { return _list; }
    }

    /// <summary>
    /// Call in repository for database
    /// </summary>
    public IEnumerable<ExpressionFieldDefinition<T, object>> ExpressionFields {
        get { return _expressionFieldDefinitions; }
    }
}