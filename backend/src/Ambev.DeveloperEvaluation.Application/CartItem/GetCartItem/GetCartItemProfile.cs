using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItem;

/// <summary>
/// Profile for mapping between CartItem entity and GetCartItemResponse
/// </summary>
public class GetCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItem operation
    /// </summary>
    public GetCartItemProfile()
    {
        CreateMap<CartItem, GetCartItemResult>();
    }
}
