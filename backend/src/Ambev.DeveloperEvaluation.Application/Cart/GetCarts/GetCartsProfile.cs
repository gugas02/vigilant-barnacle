using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Profile for mapping between Cart entity and GetCartsResponse
/// </summary>
public class GetCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCarts operation
    /// </summary>
    public GetCartsProfile()
    {
        CreateMap<Cart, GetCartsResult>();
        // CreateMap<PaginatedQueryResult<Cart>, PaginatedList<GetCartsResult>>();
        CreateMap(typeof(PaginatedQueryResult<>), typeof(PaginatedList<>));
    }
}
