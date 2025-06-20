using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a cart in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Cart : BaseEntity
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
    public List<CartItem> Products { get; set; }

    /// <summary>
    /// Gets the cart's user.
    /// Must not be null or empty and should contain user.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets the date and time when the cart was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the cart's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public Cart()
    {
        CreatedAt = DateTime.UtcNow;
        User = new User();
        Products = new List<CartItem>();
    }

    /// <summary>
    /// Performs validation of the cart entity using the CartValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Title format and length</list>
    /// <list type="bullet">Description format and length</list>
    /// <list type="bullet">Category format and length</list>
    /// <list type="bullet">Image format and length</list>
    /// <list type="bullet">Price format</list>
    /// <list type="bullet">Rating format</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }


    /// <summary>
    /// Update cart data.
    /// Set cart's user.
    /// </summary>
    public void SetUser(User user)
    {
        User = user;
    }

    /// <summary>
    /// Update cart data.
    /// Set cart products.
    /// </summary>
    public void SetProducts(List<Product> products)
    {
        foreach (var item in Products)
        {
            var itemFound = products.FirstOrDefault(x => x.Id == item.ProductId);
            if (itemFound is null)
            {
                continue;
            }
            item.Product = itemFound;
        }
    }

    /// <summary>
    /// Update cart data.
    /// Changes the cart's status to Blocked.
    /// </summary>
    public void Update(Cart cart)
    {
        Date = cart.Date;
        UserId = cart.UserId;
        SetUser(cart.User);
        UpdateProducts(cart.Products);
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProducts(List<CartItem> products)
    {
        var count = 0;
        if (this.Products.Count > products.Count)
            count = this.Products.Count;
        else
            count = products.Count;

        int? removeFrom = null;
        for (int i = 0; i < count; i++)
        {
            if (this.Products.Count > i && products.Count >= i)
            {
                this.Products[i].Update(products[i]);
            }
            else if (this.Products.Count <= i && products.Count >= i)
            {
                var item = new CartItem();
                item.Update(products[i]);
                this.Products.Add(item);
            }
            else
            {
                removeFrom = i;
                break;
            }
        }

        if (removeFrom.HasValue)
        {
            this.Products = this.Products.Take(removeFrom.Value).ToList();
        }
    }
}