namespace HandicraftShop.Catalog.Infrastructure;

/// <summary> MongoDb options </summary>
public class MongoOptions
{
    public const string MongoDbSettings = "MongoDbSettings";
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}