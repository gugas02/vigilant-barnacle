using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;

/// <summary>
/// Profile for mapping between CartItem entity and UpdateCartItemResponse
/// </summary>
public class UpdateCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCartItem operation
    /// </summary>
    public UpdateCartItemProfile()
    {
        CreateMap<UpdateCartItemCommand, CartItem>();
        CreateMap<CartItem, UpdateCartItemResult>();
    }
}
