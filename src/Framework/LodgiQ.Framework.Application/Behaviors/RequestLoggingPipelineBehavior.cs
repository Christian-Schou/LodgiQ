using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace LodgiQ.Framework.Application.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var moduleName = GetModuleName(typeof(TRequest).FullName!);
        var requestName = typeof(TRequest).Name;

        Activity.Current?.SetTag("request.module", moduleName);
        Activity.Current?.SetTag("request.name", requestName);

        using (LogContext.PushProperty("Module", moduleName))
        {
            logger.LogInformation("Processing request {RequestName}", requestName);

            var result = await next();

            if (result.IsSuccess)
                logger.LogInformation("Completed request {RequestName}", requestName);
            else
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    logger.LogError("Completed request {RequestName} with error", requestName);
                }

            return result;
        }
    }

    private static string GetModuleName(string requestName)
    {
        return requestName.Split('.')[2];
    }
}