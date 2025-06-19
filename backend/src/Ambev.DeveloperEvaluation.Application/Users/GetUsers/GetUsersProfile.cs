using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Profile for mapping between User entity and GetUsersResponse
/// </summary>
public class GetUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUsers operation
    /// </summary>
    public GetUsersProfile()
    {
        CreateMap<User, GetUsersResult>();
        // CreateMap<PaginatedQueryResult<User>, PaginatedList<GetUsersResult>>();
        CreateMap(typeof(PaginatedQueryResult<>), typeof(PaginatedList<>));
    }
}
