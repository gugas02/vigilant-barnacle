using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public class GetUsersCommand : PaginationApiCommand, IRequest<PaginatedList<GetUsersResult>>
{
    
}
