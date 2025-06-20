using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

/// <summary>
/// API response model for GetCartItem operation
/// </summary>
public class GetCartItemResponse : ApiResponse
{
    /// <summary>
    /// Gets the cartItem's ProductId.
    /// Must not be null or empty and should contain ProductId.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the cartItem's Quantity.
    /// Must not be null or empty and should contain Quantity.
    /// </summary>
    public int Quantity { get; set; } 
}
