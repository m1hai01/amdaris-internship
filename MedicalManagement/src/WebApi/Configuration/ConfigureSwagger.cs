using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Configuration
{
    public static class ConfigureSwagger
    {
        public static void ConfigureSwaggerServices(this IServiceCollection services)
        {
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            //    // Configure OAuth2 authentication for Swagger
            //    var scopes = new Dictionary<string, string>
            //    {
            //        { "openid", "OpenID" },
            //        { "profile", "User profile" },
            //        //{ "api://b2c01393-ddda-4783-9d06-a1cd6f522afa", "Access to your API" },
            //        { "api://b2c01393-ddda-4783-9d06-a1cd6f522afa/User.Write", "Access application on user behalf" },
            //        { "api://b2c01393-ddda-4783-9d06-a1cd6f522afa/MedicalManagement.Read", "read" }
            //    };

            //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            Implicit = new OpenApiOAuthFlow()
            //            {
            //                AuthorizationUrl = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/authorize"),
            //                TokenUrl = new Uri("https://login.microsoftonline.com/common/v2.0/token"),
            //                Scopes = scopes,
            //            }
            //        }
            //    });

            //    // Configure Swagger UI to use OAuth2 for authentication
            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            //            },
            //            new[] { "openid", "profile",

            //                //"api://b2c01393-ddda-4783-9d06-a1cd6f522afa",

            //                "api://b2c01393-ddda-4783-9d06-a1cd6f522afa/User.Write",
            //            "api://b2c01393-ddda-4783-9d06-a1cd6f522afa/MedicalManagement.Read"}
            //        }
            //    });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                }); var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement    {
        { securitySchema, new[] { "Bearer" } }    };
                c.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}