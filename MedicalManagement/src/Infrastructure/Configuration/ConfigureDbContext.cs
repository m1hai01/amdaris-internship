using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

internal static class ConfigureDbContext
{
    internal static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MedicalContext");
        services.AddDbContext<MedicalManagementDbContext>(optionBuilder =>
        {
            optionBuilder.UseSqlServer(connectionString);
        });
        return services;
    }
}