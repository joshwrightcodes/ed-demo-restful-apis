using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WrightCodes.CleanDemo.Infrastructure;

/// <summary>
/// Registers dependencies for the infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds Infrastructure Layer Services to the Service Collection.
    /// </summary>
    /// <param name="services">
    /// Existing Service Collection.
    /// </param>
    /// <param name="configuration">
    /// Application configuration provider.
    /// </param>
    /// <returns>Updated Service Collection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        return services;
    }
}