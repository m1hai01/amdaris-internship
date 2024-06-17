using Application;
using Application.Abstractions;
using Carter;
using Domain.Models;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Configuration;

using Microsoft.AspNetCore.Identity;
using WebApi.Configuration;
using Microsoft.AspNetCore.Authentication;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Identity.Web;
using WebApi.Middlewares;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        builder.Services
            .AddAplication()
            .AddInfrastructure(builder.Configuration)
            .AddCarter(configurator: c => c.WithValidatorLifetime(ServiceLifetime.Scoped))
            .AddValidators()
            .AddMapping();

        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });

        // Add the ConfigureSwaggerServices method here
        builder.Services.ConfigureSwaggerServices();

        builder.Services.AddAuthorization();

        //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        //builder.Host.UseSerilog((context, configuration) =>
        //  configuration.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddSingleton<GlobalExceptionHandlingMiddleware>();

        var app = builder.Build();

        // Use CORS middleware
        app.UseCors("AllowAll");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId("b2c01393-ddda-4783-9d06-a1cd6f522afa");
                options.OAuthAppName("Your API - Swagger");
                options.OAuthClientSecret("Qmy8Q~WJrXRlrGf~ahV5DRnq3-ER8WG~BRIKeda-");
                options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapCarter();

        app.UseHttpsRedirection();
        app.MigrateDbContext<MedicalManagementDbContext>();

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        app.Run();
    }
}

// Expose internals to the test project (add this to your Web API project)
//[assembly: InternalsVisibleTo("TestProject")]