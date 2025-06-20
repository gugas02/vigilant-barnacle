using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class UpdateProductHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly UpdateProductHandler _handler;

    public UpdateProductHandlerTests()
    {
        _handler = new UpdateProductHandler(_productRepository, _mapper);
    }

    [Fact(DisplayName = "Should update product successfully when product exists and data is valid")]
    public async Task Handle_ValidRequest_UpdatesProduct()
    {
        var productId = Guid.NewGuid();
        var command = new UpdateProductCommand
        {
            Id = productId,
            Title = "Updated Product",
            Price = 99.99m,
            Description = "Updated description",
            Category = "Updated category",
            Image = "http://image.url",
            Rating = new Ambev.DeveloperEvaluation.Application.Common.CreateRatingCommand { Rate = 4.5m, Count = 10 }
        };
        var existingProduct = ProductTestData.GenerateValidProduct(productId);
        var mappedProduct = ProductTestData.GenerateValidProduct(productId);
        mappedProduct.Title = command.Title;
        mappedProduct.Price = command.Price;
        mappedProduct.Description = command.Description;
        mappedProduct.Category = command.Category;
        mappedProduct.Image = command.Image;
        mappedProduct.Rating = RatingTestData.GenerateValidRating();
        var updateResult = new UpdateProductResult
        {
            Id = productId,
            Title = command.Title,
            Price = command.Price,
            Description = command.Description,
            Category = command.Category,
            Image = command.Image,
            Rating = command.Rating
        };
        _productRepository.GetByIdAsync(productId, Arg.Any<CancellationToken>()).Returns(existingProduct);
        _mapper.Map<Product>(command).Returns(mappedProduct);
        _mapper.Map<UpdateProductResult>(existingProduct).Returns(updateResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(updateResult.Id, response.Id);
        Assert.Equal(updateResult.Title, response.Title);
    }

    [Fact(DisplayName = "Should throw ValidationException if product does not exist")]
    public async Task Handle_ProductNotFound_ThrowsValidationException()
    {
        var command = new UpdateProductCommand { Id = Guid.NewGuid() };
        _productRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((Product)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw DomainException if product validation fails")]
    public async Task Handle_InvalidProduct_ThrowsDomainException()
    {
        var productId = Guid.NewGuid();
        var command = new UpdateProductCommand { Id = productId, Title = "Bad", Price = -1, Description = "", Category = "", Image = "", Rating = new Ambev.DeveloperEvaluation.Application.Common.CreateRatingCommand { Rate = 10, Count = -1 } };
        var existingProduct = ProductTestData.GenerateValidProduct(productId);
        var mappedProduct = new Product();
        _productRepository.GetByIdAsync(productId, Arg.Any<CancellationToken>()).Returns(existingProduct);
        _mapper.Map<Product>(command).Returns(mappedProduct);
        await Assert.ThrowsAsync<DomainException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
