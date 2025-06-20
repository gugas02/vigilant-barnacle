using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class CartItemValidatorTests
{
    private readonly CartItemValidator _validator;

    public CartItemValidatorTests()
    {
        _validator = new CartItemValidator();
    }

    [Fact(DisplayName = "Valid cart item should pass all validation rules")]
    public void Given_ValidCartItem_When_Validated_Then_ShouldNotHaveErrors()
    {
        var item = CartItemTestData.GenerateValidCartItem();
        item.Product.Id = item.ProductId; // Ensure product id matches
        var result = _validator.TestValidate(item);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Zero quantity should fail validation")]
    public void Given_ZeroQuantity_When_Validated_Then_ShouldHaveError()
    {
        var item = CartItemTestData.GenerateValidCartItem();
        item.Quantity = 0;
        var result = _validator.TestValidate(item);
        result.ShouldHaveValidationErrorFor(x => x.Quantity);
    }

    [Fact(DisplayName = "Empty product id should fail validation")]
    public void Given_EmptyProductId_When_Validated_Then_ShouldHaveError()
    {
        var item = CartItemTestData.GenerateValidCartItem();
        item.ProductId = Guid.Empty;
        var result = _validator.TestValidate(item);
        result.ShouldHaveValidationErrorFor(x => x.ProductId);
    }
}
