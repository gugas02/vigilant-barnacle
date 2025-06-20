using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartItemTests
    {
        [Fact(DisplayName = "CartItem should have default values after instantiation")]
        public void Given_NewCartItem_When_Instantiated_Then_DefaultValuesShouldBeSet()
        {
            var item = new CartItem();
            Assert.NotNull(item.Cart);
            Assert.NotNull(item.Product);
            Assert.True(item.CreatedAt <= DateTime.UtcNow);
            Assert.Null(item.UpdatedAt);
        }

        [Fact(DisplayName = "Update should copy all fields and update UpdatedAt")]
        public void Given_CartItem_When_UpdatedWithAnotherCartItem_Then_FieldsShouldBeCopiedAndUpdatedAtSet()
        {
            var item = new CartItem();
            var updatedItem = new CartItem
            {
                ProductId = Guid.NewGuid(),
                Quantity = 5,
                Product = new Product()
            };
            var before = DateTime.UtcNow;
            item.Update(updatedItem);
            Assert.Equal(updatedItem.ProductId, item.ProductId);
            Assert.Equal(updatedItem.Quantity, item.Quantity);
            Assert.Equal(updatedItem.Product, item.Product);
            Assert.NotNull(item.UpdatedAt);
            Assert.True(item.UpdatedAt >= before);
        }

        [Fact(DisplayName = "Validation should pass for valid cart item data")]
        public void Given_ValidCartItemData_When_Validated_Then_ShouldReturnValid()
        {
            var item = CartItemTestData.GenerateValidCartItem();
            var result = item.Validate();
            Assert.True(result.IsValid);
        }
    }
}
