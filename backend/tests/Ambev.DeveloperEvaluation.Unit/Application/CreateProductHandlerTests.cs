using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using Xunit;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateProductHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly CreateProductHandler _handler;

    public CreateProductHandlerTests()
    {
        _handler = new CreateProductHandler(_productRepository, _mapper);
    }

    [Fact(DisplayName = "Should create product successfully when title is unique and data is valid")]
    public async Task Handle_ValidRequest_ReturnsCreatedProduct()
    {
        var command = new CreateProductCommand
        {
            Title = "Product A",
            Price = 10.5m,
            Description = "A test product",
            Category = "Category1",
            Image = "image.png"
        };
        var product = ProductTestData.GenerateValidProduct();
        var createdProduct = new Product { Id = Guid.NewGuid() };
        var result = new CreateProductResult { Id = createdProduct.Id, Title = command.Title, Price = command.Price, Description = command.Description, Category = command.Category, Image = command.Image };

        _productRepository.GetByProductByTitleAsync(command.Title, Arg.Any<CancellationToken>()).Returns((Product)null!);
        _mapper.Map<Product>(command).Returns(product);
        _productRepository.CreateAsync(product, Arg.Any<CancellationToken>()).Returns(createdProduct);
        _mapper.Map<CreateProductResult>(createdProduct).Returns(result);

        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(result.Id, response.Id);
        Assert.Equal(result.Title, response.Title);
    }

    [Fact(DisplayName = "Should throw ValidationException if product with same title exists")]
    public async Task Handle_ProductWithSameTitleExists_ThrowsValidationException()
    {
        var command = new CreateProductCommand { Title = "Product A" };
        var existingProduct = new Product { Title = command.Title };
        _productRepository.GetByProductByTitleAsync(command.Title, Arg.Any<CancellationToken>()).Returns(existingProduct);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw DomainException if product validation fails")]
    public async Task Handle_InvalidProduct_ThrowsDomainException()
    {
        var command = new CreateProductCommand { Title = "Product A" };
        _productRepository.GetByProductByTitleAsync(command.Title, Arg.Any<CancellationToken>()).Returns((Product)null!);
        var product = new Product();
        _mapper.Map<Product>(command).Returns(product);
        await Assert.ThrowsAsync<DomainException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
