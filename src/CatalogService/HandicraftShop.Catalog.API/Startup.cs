using HandicraftShop.Catalog.API.Options;
using HandicraftShop.Catalog.Infrastructure;
using Serilog;

internal class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {

        // Add services to the container.
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        var devOptions = _configuration.GetSection("DevOptions").Get<DevOptions>();
        if (devOptions.EnableSwagger)
            services.AddSwaggerGen();

        if (devOptions.DisableCors)
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });

        services.AddInfrastructure(_configuration);
    }

    public void Configure(WebApplication app, IWebHostEnvironment env) {
        // Configure the HTTP request pipeline
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var devOptions = _configuration.GetSection("DevOptions").Get<DevOptions>();
        if (devOptions.EnableSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        

        if (devOptions.DisableCors)
            app.UseCors("CorsPolicy");

        app.UseAuthorization();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
        });

        app.UseSerilogRequestLogging();
        
        app.Run();
    }
}