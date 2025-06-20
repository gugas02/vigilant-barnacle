using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class GeolocationValidatorTests
{
    private readonly GeolocationValidator _validator;

    public GeolocationValidatorTests()
    {
        _validator = new GeolocationValidator();
    }

    [Fact(DisplayName = "Valid geolocation should pass all validation rules")]
    public void Given_ValidGeolocation_When_Validated_Then_ShouldNotHaveErrors()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        var result = _validator.TestValidate(geo);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty latitude should fail validation")]
    public void Given_EmptyLat_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Lat = string.Empty;
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Lat);
    }

    [Fact(DisplayName = "Small latitude should fail validation")]
    public void Given_SmallLat_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Lat = "1";
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Lat);
    }

    [Fact(DisplayName = "Large latitude should fail validation")]
    public void Given_LargeLat_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Lat = "123456789101113";
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Lat);
    }

    [Fact(DisplayName = "Empty longitude should fail validation")]
    public void Given_EmptyLong_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Long = string.Empty;
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Long);
    }

    [Fact(DisplayName = "Small longitude should fail validation")]
    public void Given_SmallLong_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Long = "1";
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Long);
    }
    
    [Fact(DisplayName = "Large longitude should fail validation")]
    public void Given_LargeLong_When_Validated_Then_ShouldHaveError()
    {
        var geo = GeolocationTestData.GenerateValidGeolocation();
        geo.Long = "123456789101113";
        var result = _validator.TestValidate(geo);
        result.ShouldHaveValidationErrorFor(x => x.Long);
    }
}
