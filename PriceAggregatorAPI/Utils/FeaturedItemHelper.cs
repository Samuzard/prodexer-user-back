using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PriceAggregatorAPI.Utils;

public static class FeaturedItemHelper
{
    public static bool ValidateRequest<T>(ModelStateDictionary modelState,out List<string> errorMessage,
        Func<T, bool> validate, T validationProperty)
    {
        var result = true;
        errorMessage = [];
        
        if (!modelState.IsValid)
        {
            errorMessage.AddRange(modelState.Values
                .SelectMany(v => v.Errors
                    .Select(e => e.ErrorMessage))
                .ToList());

            result = false;
        }

        if (!validate?.Invoke(validationProperty) ?? false)
        {
            errorMessage.Add($"Property is not Valid");
            result = false;
        }
        
        return result;
    }
}