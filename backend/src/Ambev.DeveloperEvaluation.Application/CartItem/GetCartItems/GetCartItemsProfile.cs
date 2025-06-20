using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Profile for mapping between CartItem entity and GetCartItemsResponse
/// </summary>
public class GetCartItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItems operation
    /// </summary>
    public GetCartItemsProfile()
    {
        CreateMap<CartItem, GetCartItemsResult>();
        CreateMap(typeof(PaginatedQueryResult<>), typeof(PaginatedList<>));
    }
}
