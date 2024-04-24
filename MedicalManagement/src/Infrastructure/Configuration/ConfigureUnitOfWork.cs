using Application.Abstractions;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal static class ConfigureUnitOfWork
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}