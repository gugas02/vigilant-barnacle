using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class DeleteProductHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly DeleteProductHandler _handler;

    public DeleteProductHandlerTests()
    {
        _handler = new DeleteProductHandler(_productRepository, _mapper);
    }

    [Fact(DisplayName = "Should delete product successfully when product exists")]
    public async Task Handle_ValidRequest_DeletesProductAndReturnsResult()
    {
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Title = "Product A" };
        var command = new DeleteProductCommand(productId);
        var expectedResult = new DeleteProductResult { Id = productId, Title = product.Title };
        _productRepository.GetByIdAsync(productId, Arg.Any<CancellationToken>()).Returns(product);
        _mapper.Map<DeleteProductResult>(product).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.Id, response.Id);
        Assert.Equal(expectedResult.Title, response.Title);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if product does not exist")]
    public async Task Handle_ProductNotFound_ThrowsKeyNotFoundException()
    {
        var productId = Guid.NewGuid();
        var command = new DeleteProductCommand(productId);
        _productRepository.GetByIdAsync(productId, Arg.Any<CancellationToken>()).Returns((Product)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
