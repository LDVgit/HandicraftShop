namespace HandicraftShop.Catalog.API.Options
{
    /// <summary> Add otions in service collection </summary>
    public static class AddOptionSettings
    {
        /// <summary>
        /// Add dev options in service collection
        /// </summary>
        /// <param name="services"> Service ccollection </param>
        /// <param name="configuration"> Application configuration </param>
        /// <returns> Service ccollection </returns>
        public static IServiceCollection AddSharedOptions(
             this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DevOptions>
                (configuration.GetSection("DevOptions"));

            return services;
        }
    }
}