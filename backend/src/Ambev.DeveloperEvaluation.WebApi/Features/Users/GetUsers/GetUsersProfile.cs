using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Users.GetUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;

/// <summary>
/// Profile for mapping GetUsers feature requests to commands
/// </summary>
public class GetUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUsers feature
    /// </summary>
    public GetUsersProfile()
    {
        CreateMap<GetUsersRequest, GetUsersCommand>();
        CreateMap<GetUsersResult, GetUsersResponse>(); 
        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>));
    }
}
