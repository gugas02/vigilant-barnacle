using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Application.Common;
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

public class GetCartsHandlerTests
{
    private readonly ICartRepository _cartRepository = Substitute.For<ICartRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly GetCartsHandler _handler;

    public GetCartsHandlerTests()
    {
        _handler = new GetCartsHandler(_cartRepository, _mapper);
    }

    [Fact(DisplayName = "Should return paginated list of carts when carts exist")]
    public async Task Handle_ValidRequest_ReturnsPaginatedCarts()
    {
        var command = new GetCartsCommand { Page = 1, Size = 10, Order = "date" };
        var paginatedCarts = new PaginatedQueryResult<Cart>(new List<Cart> { new Cart { Id = Guid.NewGuid() } }, 1, 1, 10);
        var expectedResult = new PaginatedList<GetCartsResult>(new List<GetCartsResult> { new GetCartsResult { Id = paginatedCarts.Data.First().Id } }, 1, 1, 10);
        _cartRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns(paginatedCarts);
        _mapper.Map<PaginatedList<GetCartsResult>>(paginatedCarts).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.Data.Count(), response.Data.Count());
        Assert.Equal(expectedResult.Data.First().Id, response.Data.First().Id);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if no carts exist")]
    public async Task Handle_NoCartsFound_ThrowsKeyNotFoundException()
    {
        var command = new GetCartsCommand { Page = 1, Size = 10, Order = "date" };
        _cartRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns((PaginatedQueryResult<Cart>)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
