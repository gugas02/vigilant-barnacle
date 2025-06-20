using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class NameValidatorTests
{
    private readonly NameValidator _validator;

    public NameValidatorTests()
    {
        _validator = new NameValidator();
    }

    [Fact(DisplayName = "Valid name should pass all validation rules")]
    public void Given_ValidName_When_Validated_Then_ShouldNotHaveErrors()
    {
        var name = NameTestData.GenerateValidName();
        var result = _validator.TestValidate(name);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty firstname should fail validation")]
    public void Given_EmptyFirstname_When_Validated_Then_ShouldHaveError()
    {
        var name = NameTestData.GenerateValidName();
        name.Firstname = string.Empty;
        var result = _validator.TestValidate(name);
        result.ShouldHaveValidationErrorFor(x => x.Firstname);
    }

    [Fact(DisplayName = "Empty lastname should fail validation")]
    public void Given_EmptyLastname_When_Validated_Then_ShouldHaveError()
    {
        var name = NameTestData.GenerateValidName();
        name.Lastname = string.Empty;
        var result = _validator.TestValidate(name);
        result.ShouldHaveValidationErrorFor(x => x.Lastname);
    }
}
