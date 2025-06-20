using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Common;
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

public class GetProductsHandlerTests
{
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly GetProductsHandler _handler;

    public GetProductsHandlerTests()
    {
        _handler = new GetProductsHandler(_productRepository, _mapper);
    }

    [Fact(DisplayName = "Should return paginated list of products when products exist")]
    public async Task Handle_ValidRequest_ReturnsPaginatedProducts()
    {
        var command = new GetProductsCommand { Page = 1, Size = 10, Order = "title" };
        var paginatedProducts = new PaginatedQueryResult<Product>(new List<Product> { new Product { Id = Guid.NewGuid() } }, 1, 1, 10);
        var expectedResult = new PaginatedList<GetProductsResult>(new List<GetProductsResult> { new GetProductsResult { Id = paginatedProducts.Data.First().Id } }, 1, 1, 10);
        _productRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns(paginatedProducts);
        _mapper.Map<PaginatedList<GetProductsResult>>(paginatedProducts).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.TotalItems, response.TotalItems);
        Assert.Equal(expectedResult.Data.First().Id, response.Data.First().Id);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if no products exist")]
    public async Task Handle_NoProductsFound_ThrowsKeyNotFoundException()
    {
        var command = new GetProductsCommand { Page = 1, Size = 10, Order = "title" };
        _productRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns((PaginatedQueryResult<Product>)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
