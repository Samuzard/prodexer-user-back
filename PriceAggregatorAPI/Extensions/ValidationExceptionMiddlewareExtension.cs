using PriceAggregatorAPI.Middleware;

namespace PriceAggregatorAPI.Extensions;

public static class ValidationExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationExceptionMiddleware>();
    }
}
