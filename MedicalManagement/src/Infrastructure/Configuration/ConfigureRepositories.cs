using Application.Abstractions;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

internal static class ConfigureRepositories
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    => services.AddScoped<IUserRepository, UserRepository>();
}