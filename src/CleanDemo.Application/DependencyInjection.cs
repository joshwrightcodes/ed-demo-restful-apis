using Microsoft.Extensions.DependencyInjection;

namespace WrightCodes.CleanDemo.Application;

/// <summary>
/// Registers dependencies for the application layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds Application Layer Services to the Service Collection.
    /// </summary>
    /// <param name="services">Existing Service Collection.</param>
    /// <returns>Updated Service Collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services;
    }
}