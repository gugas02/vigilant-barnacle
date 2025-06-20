using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class ProductTestData
    {
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
            .RuleFor(p => p.Image, f => f.Image.PicsumUrl())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.Rating, f => null); // Adjust as needed for Rating

        public static Product GenerateValidProduct()
        {
            return ProductFaker.Generate();
        }

        public static Product GenerateValidProduct(Guid id)
        {
            var product = GenerateValidProduct();
            product.Id = id;
            return product;
        }
    }
}
