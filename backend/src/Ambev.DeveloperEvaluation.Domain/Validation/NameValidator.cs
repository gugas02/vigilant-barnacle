using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(name => name.Firstname)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Firstname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Firstname cannot be longer than 50 characters.");

        RuleFor(name => name.Lastname)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Lastname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Lastname cannot be longer than 50 characters.");
    }
}
