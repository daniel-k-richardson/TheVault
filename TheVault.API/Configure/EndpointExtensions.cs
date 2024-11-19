using Microsoft.Extensions.DependencyInjection.Extensions;
using TheVault.API.Interfaces;

namespace TheVault.API.Configure;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var assembly = typeof(Program).Assembly;
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoints)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoints), type));
        services.TryAddEnumerable(serviceDescriptors);
        return services;
    }
}
