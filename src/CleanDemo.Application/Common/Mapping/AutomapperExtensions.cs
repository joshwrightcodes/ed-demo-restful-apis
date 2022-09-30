using System.Reflection;
using AutoMapper;

namespace WrightCodes.CleanDemo.Application.Common.Mapping;

/// <summary>
/// Extensions Methods for <see cref="IMapFrom{T}"/> and AutoMapper.
/// </summary>
public static class AutomapperExtensions
{
    /// <summary>
    /// Applies a base mapping for any object that implements <see cref="IMapFrom{T}"/>.
    /// Overridden mappings are applied from the class if <paramref name="profile"/>
    /// is implemented in the class.
    /// </summary>
    /// <param name="profile">Mapping Profile.</param>
    /// <param name="assembly">Assembly to load mappings from.</param>
    public static void ApplyMappingsFromAssembly(this Profile profile, Assembly assembly)
    {
        if (assembly is null)
        {
            throw new ArgumentNullException(nameof(assembly));
        }

        if (profile is null)
        {
            throw new ArgumentNullException(nameof(profile));
        }

        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (Type type in types)
        {
            object instance = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { profile });
        }
    }
}