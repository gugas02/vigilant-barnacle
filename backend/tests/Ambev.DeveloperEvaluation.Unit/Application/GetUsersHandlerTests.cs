using Xunit;
using Ambev.DeveloperEvaluation.Application.Users.GetUsers;
using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class GetUsersHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly GetUsersHandler _handler;

    public GetUsersHandlerTests()
    {
        _handler = new GetUsersHandler(_userRepository, _mapper);
    }

    [Fact(DisplayName = "Should return paginated list of users when users exist")]
    public async Task Handle_ValidRequest_ReturnsPaginatedUsers()
    {
        var command = new GetUsersCommand { Page = 1, Size = 10, Order = "username" };
        var paginatedUsers = new PaginatedQueryResult<User>(new List<User> { new User { Id = Guid.NewGuid() } }, 1, 1, 10);
        var expectedResult = new PaginatedList<GetUsersResult>(new List<GetUsersResult> { new GetUsersResult { Id = paginatedUsers.Data.First().Id } }, 1, 1, 10);
        _userRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns(paginatedUsers);
        _mapper.Map<PaginatedList<GetUsersResult>>(paginatedUsers).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.TotalItems, response.TotalItems);
        Assert.Equal(expectedResult.Data.First().Id, response.Data.First().Id);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if no users exist")]
    public async Task Handle_NoUsersFound_ThrowsKeyNotFoundException()
    {
        var command = new GetUsersCommand { Page = 1, Size = 10, Order = "username" };
        _userRepository.ListAsync(command.Page, command.Size, command.Order, Arg.Any<CancellationToken>()).Returns((PaginatedQueryResult<User>)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
