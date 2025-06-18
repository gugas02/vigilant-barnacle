using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Validator for CreateNameRequest that defines validation rules for user creation.
/// </summary>
public class CreateNameRequestValidator : AbstractValidator<CreateNameRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateNameRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Firstname: Required, length between 2 and 50 characters
    /// - Lastname: Required, length between 2 and 50 characters
    /// </remarks>
    public CreateNameRequestValidator()
    {
        RuleFor(user => user.Firstname).NotEmpty().Length(2, 50);
        RuleFor(user => user.Lastname).NotEmpty().Length(2, 50);
    }
}