using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class AddressValidatorTests
{
    private readonly AddressValidator _validator;

    public AddressValidatorTests()
    {
        _validator = new AddressValidator();
    }

    [Fact(DisplayName = "Valid address should pass all validation rules")]
    public void Given_ValidAddress_When_Validated_Then_ShouldNotHaveErrors()
    {
        var address = AddressTestData.GenerateValidAddress();
        var result = _validator.TestValidate(address);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty city should fail validation")]
    public void Given_EmptyCity_When_Validated_Then_ShouldHaveError()
    {
        var address = AddressTestData.GenerateValidAddress();
        address.City = string.Empty;
        var result = _validator.TestValidate(address);
        result.ShouldHaveValidationErrorFor(x => x.City);
    }

    [Fact(DisplayName = "Empty Street should fail validation")]
    public void Given_EmptyStreet_When_Validated_Then_ShouldHaveError()
    {
        var address = AddressTestData.GenerateValidAddress();
        address.Street = string.Empty;
        var result = _validator.TestValidate(address);
        result.ShouldHaveValidationErrorFor(x => x.Street);
    }

    [Fact(DisplayName = "Empty number should fail validation")]
    public void Given_EmptyNumber_When_Validated_Then_ShouldHaveError()
    {
        var address = AddressTestData.GenerateValidAddress();
        address.Number = string.Empty;
        var result = _validator.TestValidate(address);
        result.ShouldHaveValidationErrorFor(x => x.Number);
    }

    [Fact(DisplayName = "Empty zipcode should fail validation")]
    public void Given_EmptyZipcode_When_Validated_Then_ShouldHaveError()
    {
        var address = AddressTestData.GenerateValidAddress();
        address.Zipcode = string.Empty;
        var result = _validator.TestValidate(address);
        result.ShouldHaveValidationErrorFor(x => x.Zipcode);
    }
}
