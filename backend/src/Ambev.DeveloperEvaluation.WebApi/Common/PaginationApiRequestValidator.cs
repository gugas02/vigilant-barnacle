using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

/// <summary>
/// Validator for PaginatedApiRequestt
/// </summary>
public class PaginationApiRequestValidator : AbstractValidator<PaginationApiRequest>
{
    /// <summary>
    /// Initializes validation rules for PaginatedApiRequestt
    /// </summary>
    public PaginationApiRequestValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Order), () =>
        {
            RuleFor(x => x.Order).NotEmpty().Length(3, 50);
        });
    }
}
