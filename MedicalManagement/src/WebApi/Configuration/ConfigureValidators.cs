using FluentValidation;
using WebApi.Endpoints.Users.Create;

namespace WebApi.Configuration
{
    internal static class ConfigureValidators
    {
        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services.AddValidatorsFromAssemblyContaining<Program>();
    }
}