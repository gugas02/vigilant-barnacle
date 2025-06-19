using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

/// <summary>
/// Validator for PaginationApiCommand
/// </summary>
public class PaginationApiCommandValidator : AbstractValidator<PaginationApiCommand>
{
    /// <summary>
    /// Initializes validation rules for PaginationApiCommand
    /// </summary>
    public PaginationApiCommandValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Order), () =>
        {
            RuleFor(x => x.Order).NotEmpty().Length(3, 50);
        });
    }
}
