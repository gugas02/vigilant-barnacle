namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItem;

/// <summary>
/// Response model for GetCartItem operation
/// </summary>
public class GetCartItemResult
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
