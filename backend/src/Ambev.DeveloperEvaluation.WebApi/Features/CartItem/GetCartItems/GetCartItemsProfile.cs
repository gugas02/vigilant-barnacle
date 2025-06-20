using Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItems;

/// <summary>
/// Profile for mapping GetCartItems feature requests to commands
/// </summary>
public class GetCartItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItems feature
    /// </summary>
    public GetCartItemsProfile()
    {
        CreateMap<GetCartItemsResult, GetCartItemsResponse>(); 
    }
}
