using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configuration
{
    public static class ConfigureDb
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MedicalContext");
            services.AddDbContext<MedicalManagementDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(connectionString);
            });
            return services;
        }

        public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider>? seeder = null)
    where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}",
                    typeof(TContext).Name);

                var retries = 10;
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                        retries,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        (exception, timeSpan, retry, ctx) =>
                        {
                            logger.LogWarning(exception,
                                "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}",
                                nameof(TContext), exception.GetType().Name, exception.Message, retry, retries);
                        });

                retry.Execute(() =>
                {
                    context.Database.Migrate();
                    seeder?.Invoke(context, services);
                });

                logger.LogInformation("Migrated database associated with context {DbContextName}",
                    typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}",
                    typeof(TContext).Name);
            }

            return host;
        }
    }
}