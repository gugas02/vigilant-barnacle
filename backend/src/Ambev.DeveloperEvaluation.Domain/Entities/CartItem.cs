using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a cart item in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class CartItem : BaseEntity
{ 

    /// <summary>
    /// Gets the cart item's cart id.
    /// Must not be null or empty and should contain cart id.
    /// </summary>
    public Guid CartId { get; set; }
  
    /// <summary>
    /// Gets the cart item's product id.
    /// Must not be null or empty and should contain product id.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the cart item's quantity.
    /// Must not be null or empty and should contain quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the cart item's cart.
    /// Must not be null or empty and should contain cart.
    /// </summary>
    public Cart Cart { get; set; }

    /// <summary>
    /// Gets the cart item's product.
    /// Must not be null or empty and should contain product.
    /// </summary>
    public Product Product { get; set; } 

    /// <summary>
    /// Gets the date and time when the cart item was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the cart item's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public CartItem()
    {
        CreatedAt = DateTime.UtcNow;
        Cart = new Cart();
        Product = new Product();
    }

    /// <summary>
    /// Performs validation of the cart item entity using the CartItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">CartId filled</list>
    /// <list type="bullet">ProductId filled</list>
    /// <list type="bullet">Quantity ammount</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
  
    /// <summary>
    /// Update cart item data.
    /// </summary>
    public void Update(CartItem cart)
    {
        ProductId = cart.ProductId;
        Quantity = cart.Quantity;
        Product =  cart.Product; 
        UpdatedAt = DateTime.UtcNow;
    }
}