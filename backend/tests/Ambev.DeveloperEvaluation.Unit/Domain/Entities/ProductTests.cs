using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        [Fact(DisplayName = "Product should have default values after instantiation")]
        public void Given_NewProduct_When_Instantiated_Then_DefaultValuesShouldBeSet()
        {
            var product = new Product();
            Assert.Equal(string.Empty, product.Title);
            Assert.Equal(string.Empty, product.Description);
            Assert.Equal(string.Empty, product.Category);
            Assert.Equal(string.Empty, product.Image);
            Assert.True(product.CreatedAt <= DateTime.UtcNow);
            Assert.Null(product.UpdatedAt);
        }

        [Fact(DisplayName = "Update should copy all fields and update UpdatedAt")]
        public void Given_Product_When_UpdatedWithAnotherProduct_Then_FieldsShouldBeCopiedAndUpdatedAtSet()
        { 
            var product = ProductTestData.GenerateValidProduct();
            var updatedProduct = new Product
            {
                Title = "New Title",
                Price = 99.99m,
                Description = "New Description",
                Category = "New Category",
                Image = "image.png",
                Rating = null
            };
            var before = DateTime.UtcNow;
            product.Update(updatedProduct);
            Assert.Equal(updatedProduct.Title, product.Title);
            Assert.Equal(updatedProduct.Price, product.Price);
            Assert.Equal(updatedProduct.Description, product.Description);
            Assert.Equal(updatedProduct.Category, product.Category);
            Assert.Equal(updatedProduct.Image, product.Image);
            Assert.Equal(updatedProduct.Rating, product.Rating);
            Assert.NotNull(product.UpdatedAt);
            Assert.True(product.UpdatedAt >= before);
        }

        [Fact(DisplayName = "Validation should pass for valid product data")]
        public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
        {
            var product = ProductTestData.GenerateValidProduct();
            var result = product.Validate();
            Assert.True(result.IsValid);
        }
    }
}
