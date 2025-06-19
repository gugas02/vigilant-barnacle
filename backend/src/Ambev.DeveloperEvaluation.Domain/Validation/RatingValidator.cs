using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class RatingValidator : AbstractValidator<Rating>
{
    public RatingValidator()
    {
        RuleFor(name => name.Rate)
            .NotNull()
            .GreaterThanOrEqualTo(0).WithMessage("Rate must be greater or equal to 0.")
            .LessThanOrEqualTo(5).WithMessage("Rate must be less or equal to 5.");

        RuleFor(name => name.Count)
            .NotNull()
            .GreaterThanOrEqualTo(0).WithMessage("Count must be greater or equal to 0.");
    }
}
