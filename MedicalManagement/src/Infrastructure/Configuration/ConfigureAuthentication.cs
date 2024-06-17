using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal static class ConfigureAuthentication
    {
        public static IServiceCollection AddMicrosoftAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(options =>
                {
                    options.Authority = $"https://login.microsoftonline.com/{configuration["AzureAd:TenantId"]}/v2.0";
                    configuration.Bind("AzureAd", options);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudiences = new[]
                        {
                            "84b11a45-014a-4eab-b07a-6641910f07a1", // Frontend client ID
                            configuration["AzureAd:ClientId"] // Backend API client ID
                        }
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            string[] allowedClientApps =
                            {
                                configuration["AzureAd:FrontClientId"] // Frontend client ID
                            };
                            string clientAppId = context?.Principal?.Claims
                                .FirstOrDefault(x => x.Type == "azp" || x.Type == "appid")?.Value;

                            if (!allowedClientApps.Contains(clientAppId))
                            {
                                throw new UnauthorizedAccessException("The client app is not permitted to access this API");
                            }

                            await Task.CompletedTask;
                        }
                    };
                }, options =>
                {
                    configuration.Bind("AzureAd", options);
                });

            // The following flag can be used to get more descriptive errors in development environments
            // Enable diagnostic logging to help with troubleshooting.  For more details, see https://aka.ms/IdentityModel/PII.
            // You might not want to keep this following flag on for production
            IdentityModelEventSource.ShowPII = true;

            return services;
        }
    }
}