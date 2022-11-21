using HandicraftShop.Catalog.API;
using HandicraftShop.Catalog.API.Options;
using HandicraftShop.Catalog.Infrastructure;
using Serilog;

Log.Logger = SerilogSettings.UseGlobalSerilog();
Log.Information("Starting host {date}.", DateTime.Now);

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilogHostBuilder();

    var services = builder.Services;

    // Add services to the container.
    services.AddControllers();
    services.AddEndpointsApiExplorer();

    var configurations = builder.Configuration;
    var devOptions = configurations.GetSection("DevOptions").Get<DevOptions>();

    if (devOptions.EnableSwagger)
        builder.Services.AddSwaggerGen();

    if (devOptions.DisableCors)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
        });
    services.AddInfrastructure(configurations);

    var app = builder.Build();


    // Configure the HTTP request pipeline.
    if (devOptions.EnableSwagger)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    if (devOptions.DisableCors)
        app.UseCors("CorsPolicy");

    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoint =>
    {
        endpoint.MapControllers();
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}