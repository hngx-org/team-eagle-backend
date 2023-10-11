using Microsoft.AspNetCore.Diagnostics;
using Zuri_Portfolio_Explore.Domains.ErrorModels;

namespace Zuri_Portfolio_Explore.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogWarning($"{contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Failed to retrieve items",
                        }.ToString());
                    }
                });
            });
        }
    }
}
