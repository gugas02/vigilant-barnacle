using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.WebApi.Filters;

[ExcludeFromCodeCoverage]
public class ValidationActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var item in context.ActionArguments)
        {
            if (item.Value is ApiRequest)
            {
                Type propType = item.Value.GetType();
                Type validatorType = typeof(IValidator<>).MakeGenericType(propType);
                if (context.HttpContext.RequestServices.GetService(validatorType) is not IValidator validator)
                {
                    throw new InvalidOperationException($"No validator found for: {propType.Name}");
                }

                Type contextType = typeof(ValidationContext<>).MakeGenericType(propType);
                if (Activator.CreateInstance(contextType, item.Value) is not IValidationContext validationContext)
                {
                    throw new InvalidOperationException($"It was not possibly to create validation context for: {propType.Name}");
                }
                
                var result = await validator.ValidateAsync(validationContext, context.HttpContext.RequestAborted);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
        }
        await next();
    }
}
