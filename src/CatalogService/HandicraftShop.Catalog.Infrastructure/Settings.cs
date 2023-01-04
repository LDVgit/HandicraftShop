namespace HandicraftShop.Catalog.Infrastructure;

using HandicraftShop.Catalog.Infrastructure.Mappings;
using HandicraftShop.Extensions;
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
}