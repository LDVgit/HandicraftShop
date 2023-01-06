namespace HandicraftShop.Catalog.Infrastructure;

using HandicraftShop.Catalog.Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Setup
{
    /// <summary>
    ///     Add Infrastructure services to Service Collection.
    /// </summary>
    /// <param name="services"> Service Collection. </param>
    /// <param name="configuration">  application configuration properties </param>
    /// <returns> Service Collection. </returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDataMappers();
        return services;
    }

    /// <summary>
    ///     Add repositories from Infrastructure.
    /// </summary>
    /// <param name="services"> Service Collection. </param>
    /// <returns> Service Collection. </returns>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    /// <summary>
    /// Add entity mappers.
    /// </summary>
    /// <param name="services"> Service Collection. </param>
    /// <returns> Service Collection. </returns>
    private static IServiceCollection AddDataMappers(this IServiceCollection services)
    {
        services.AddSingleton<IDataMapper, MascotMapper>();
        services.AddSingleton<IDataMapper, ImageMapper>();
        services.AddSingleton<IDataMapper, CategoryMapper>();
        services.AddSingleton<IDataMapper, CategoryTypeMapper>();

        services.CallRegisterMaps();
        return services;
    }
}