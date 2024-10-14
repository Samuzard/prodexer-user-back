﻿using PriceAggregatorAPI;
using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Middleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ValidationExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = 400;
                var validationFailureResponse = new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { exception.ToString() }
                };
                await context.Response.WriteAsJsonAsync(validationFailureResponse);
            }
        }
    }
}
