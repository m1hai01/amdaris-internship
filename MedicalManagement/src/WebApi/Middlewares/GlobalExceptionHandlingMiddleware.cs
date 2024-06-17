using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Start the stopwatch to measure the request processing time
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Let the request pass through the pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during request processing
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                // Stop the stopwatch and log the elapsed time
                stopwatch.Stop();
                _logger.LogInformation($"Request processed in {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}