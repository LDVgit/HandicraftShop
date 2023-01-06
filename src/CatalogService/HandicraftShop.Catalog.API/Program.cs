using HandicraftShop.Catalog.API;
using Serilog;

Log.Logger = SerilogSettings.UseGlobalSerilog();
Log.Information("Starting host {date}.", DateTime.Now);

try
{
    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services); // calling ConfigureServices method
    var app = builder.Build();
    startup.Configure(app, builder.Environment); // calling Configure method
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