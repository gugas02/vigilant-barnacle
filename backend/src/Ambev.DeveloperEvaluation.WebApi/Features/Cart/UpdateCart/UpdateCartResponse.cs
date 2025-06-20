using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// API response model for UpdateCart operation
/// </summary>
public class UpdateCartResponse : ApiResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created cart.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created cart in the system.</value>
    public Guid Id { get; set; }

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
    public List<UpdateCartItemResponse> Products { get; set; }
}
