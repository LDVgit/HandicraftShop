namespace HandicraftShop.Extensions;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

/// <summary> ServiceCollection Extensions. </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Inject all instances of a service interface
    /// </summary>
    /// <param name="services"> Specifies the contract for a collection of service descriptors. </param>
    /// <param name="assemblies">
    ///     Represents an assembly, which is a reusable, versionable, and self-describing building block
    ///     of a CLR application.
    /// </param>
    /// <param name="lifetime"> Specifies the lifetime of a service in an IServiceCollection. </param>
    /// <typeparam name="T"> Type/interface </typeparam>
    /// <example>
    ///  <!-- services.RegisterAllTypes<IRequest> (new[] { typeof(Startup).Assembly }); -->
    /// </example>
    public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var typesFromAssemblies =
            assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies)
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
    }

    /// <summary>
    ///     Inject all instances of a generic service interface
    /// </summary>
    /// <param name="services"> Specifies the contract for a collection of service descriptors. </param>
    /// <param name="genericType"> Type of generis service. </param>
    /// <param name="assemblies">
    ///     Represents an assembly, which is a reusable, versionable, and self-describing building block
    ///     of a CLR application.
    /// </param>
    /// <param name="lifetime"> Specifies the lifetime of a service in an IServiceCollection. </param>
    /// <example>
    ///   services.AddAllGenericTypes(typeof(IRequest), new[] {typeof(Startup).Assembly});
    /// </example>
    public static void RegisterAllGenericTypes(this IServiceCollection services, Type genericType,
        Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType)));

        foreach (var type in typesFromAssemblies)
        {
            services.Add(new ServiceDescriptor(genericType, type, lifetime));
        }
    }
}