using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CleanArchAndCQRS.Infrastructure.Logging
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.Request;
            var commandName = request.Path.Value;
            var message = $"Received {commandName} command.";
            _logger.LogInformation(message);

            try
            {
                _logger.LogInformation(message);
                await next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to process {commandName} command.");

                throw;
            }

            _logger.LogInformation($"Handled {commandName} command.");


        }
    }
}

