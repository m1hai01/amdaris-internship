using Application.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    //add mediatr and fluent library
    //configure dependency injection
    public static IServiceCollection AddAplication(this IServiceCollection services) =>
        services
            .AddMediatR();
}