using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

internal static class ConfigureMediatR
{
    public static IServiceCollection AddMediatR(this IServiceCollection services) =>
        services.AddMediatR(b => b.RegisterServicesFromAssembly(typeof(ConfigureMediatR).Assembly));
}