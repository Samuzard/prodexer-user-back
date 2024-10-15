using PriceAggregatorAPI;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace PriceAggregatorAPI.Middleware
{
    public class ValidationExceptionMiddleware(RequestDelegate request)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (ValidationException exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var validationFailureResponse = new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessages = [exception.ToString()]
                };
                var result = JsonSerializer.Serialize(validationFailureResponse);
                
                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
