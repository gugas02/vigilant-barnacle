namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;

/// <summary>
/// Represents the response returned after successfully creating a new cartItem.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created cartItem,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateCartItemResult
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
