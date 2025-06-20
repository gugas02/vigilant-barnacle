namespace Ambev.DeveloperEvaluation.Application.CartItems.GetCartItems;

/// <summary>
/// Response model for GetCartItems operation
/// </summary>
public class GetCartItemsResult
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
