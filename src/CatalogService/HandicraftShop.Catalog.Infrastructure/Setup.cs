namespace HandicraftShop.Catalog.Infrastructure;

using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

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
        return services;
    }

    /// <summary>
    ///     Add repositories from Infrastructure.
    /// </summary>
    /// <param name="services"> Service Collection. </param>
    /// <returns> Service Collection. </returns>
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IMascotRepository, MascotRepository>();
    }
}