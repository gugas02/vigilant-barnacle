using Ambev.DeveloperEvaluation.Application.CartItems.GetCartItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

/// <summary>
/// Profile for mapping GetCartItem feature requests to commands
/// </summary>
public class GetCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItem feature
    /// </summary>
    public GetCartItemProfile()
    {
        CreateMap<GetCartItemResult, GetCartItemResponse>();
    }
}
