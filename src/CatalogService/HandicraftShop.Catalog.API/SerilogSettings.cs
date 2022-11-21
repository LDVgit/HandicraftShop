#region

using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

#endregion

namespace HandicraftShop.Catalog.API;

/// <summary> Serilog Settings </summary>
public static class SerilogSettings
{
    /// <summary>
    ///     Add loggger in host
    /// </summary>
    /// <param name="builder"> Host builder. </param>
    /// <returns> Service collection. </returns>
    public static IHostBuilder UseSerilogHostBuilder(this IHostBuilder builder)
    {
        builder.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
        );
        return builder;
    }

    /// <summary>
    ///     Add serilog to global
    /// </summary>
    /// <remarks> Call before initialization host.</remarks>
    public static ILogger UseGlobalSerilog()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .CreateBootstrapLogger();
    }
}