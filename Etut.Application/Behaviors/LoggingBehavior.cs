

using MediatR;
using Microsoft.Extensions.Logging;


namespace CQRSExample.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Log request details
            _logger.LogInformation("Handling {RequestName} with payload: {@Request}", typeof(TRequest).Name, request);

            // Call the next handler in the pipeline
            var response = await next();

            // Log response details
            _logger.LogInformation("Handled {RequestName} with response: {@Response}", typeof(TRequest).Name, response);

            return response;
        }
    }
}