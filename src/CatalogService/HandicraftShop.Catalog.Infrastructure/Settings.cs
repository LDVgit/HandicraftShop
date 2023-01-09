namespace HandicraftShop.Catalog.Infrastructure;

using HandicraftShop.Catalog.Infrastructure.Mappings;
using HandicraftShop.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class CreateMaps
{
    /// <summary>
    /// Call RegisterMap method. 
    /// </summary>
    /// <remarks>
    /// Call after register IDataMapper instances.
    /// </remarks>
    /// <param name="services"> Service Collection. </param>
    internal static void CallRegisterMaps(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var mappers = provider.GetServices<IDataMapper>();
        mappers.ForEach(x =>
        {
            x.RegisterCLassMap();
        });
    }

    /// <summary>
    /// Add db setting to dependency injection service container.
    /// </summary>
    /// <param name="services">Service Collection.</param>
    /// <param name="configuration">Configuration.</param>
    internal static void AddMongoOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoOptions>(configuration.GetSection(MongoOptions.MongoDbSettings));
    }
}