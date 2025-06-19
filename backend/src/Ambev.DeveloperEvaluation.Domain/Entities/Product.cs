using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a product in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Gets the product's title.
    /// Must not be null or empty and should contain title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's price.
    /// Must not be null or empty and should contain price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product's description.
    /// Must not be null or empty and should contain description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's category.
    /// Must not be null or empty and should contain category.
    /// </summary>    
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's image.
    /// Must not be null or empty and should contain image.
    /// </summary>    
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's rating.
    /// Must not be null or empty and should contain rating.
    /// </summary>
    public Rating Rating { get; set; }

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the product entity using the ProductValidator rules.
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
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
  
    /// <summary>
    /// Update product data.
    /// Changes the product's status to Blocked.
    /// </summary>
    public void Update(Product product)
    {
        Title = product.Title;
        Price = product.Price;
        Description = product.Description;
        Category = product.Category;
        Image = product.Image;
        Rating = product.Rating;
        UpdatedAt = DateTime.UtcNow;
    }
}