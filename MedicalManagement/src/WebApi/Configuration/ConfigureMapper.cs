using FluentValidation;
using WebApi.Endpoints.Users.Mapping;

namespace WebApi.Configuration
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}