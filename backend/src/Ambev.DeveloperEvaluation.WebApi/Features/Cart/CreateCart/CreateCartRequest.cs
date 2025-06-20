using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new cart in the system.
/// </summary>
public class CreateCartRequest : ApiRequest
{ 
    /// <summary>
    /// Gets the date and time when the cart was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the cart's user id.
    /// Must not be null or empty and should contain user id.
    /// </summary>
    public Guid UserId { get; set; }
   
    /// <summary>
    /// Gets the cart's products.
    /// Must not be null or empty and should contain products.
    /// </summary>
    public List<CreateCartItemRequest> Products { get; set; } 
}