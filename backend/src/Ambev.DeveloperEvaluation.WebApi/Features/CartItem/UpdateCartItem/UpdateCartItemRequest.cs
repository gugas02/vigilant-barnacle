using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// Represents a request to create a new cartItem in the system.
/// </summary>
public class UpdateCartItemRequest : ApiRequest
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