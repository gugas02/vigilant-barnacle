using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

/// <summary>
/// Represents a request to create a new cartItem in the system.
/// </summary>
public class CreateCartItemRequest : ApiRequest
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