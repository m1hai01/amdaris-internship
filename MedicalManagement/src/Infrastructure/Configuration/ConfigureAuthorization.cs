using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    internal static class ConfigureAuthorization
    {
        public static IServiceCollection AddJWTAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApi(
                        jwtOptions => configuration.Bind("AzureAd", jwtOptions),
                        identityOptions => configuration.Bind("AzureAd", identityOptions)
                    );

            return services;
        }
    }
}