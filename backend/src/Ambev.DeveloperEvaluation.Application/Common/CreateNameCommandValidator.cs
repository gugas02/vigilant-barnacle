using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Validator for CreateNameCommand that defines validation rules for name creation.
/// </summary>
public class CreateNameCommandValidator : AbstractValidator<CreateNameCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateNameCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Firstname: Required, length between 2 and 50 characters
    /// - Lastname: Required, length between 2 and 50 characters
    /// </remarks>
    public CreateNameCommandValidator()
    {
        RuleFor(user => user.Firstname).NotEmpty().Length(2, 50);
        RuleFor(user => user.Lastname).NotEmpty().Length(2, 50);
    }
}