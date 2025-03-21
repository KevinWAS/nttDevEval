using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a product sell in the system
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Products : BaseEntity
{

    /// <summary>
    /// Title of the Product
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description of the Product
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Price of the Product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Rating of the Product
    /// </summary>
    public decimal ratingRate { get; set; }

    /// <summary>
    /// Quantity of products on that rate
    /// </summary>
    public int ratingCount { get; set; }

    /// <summary>
    /// Date of the Product
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }


    /// <summary>
    /// CartId owner of the Product
    /// </summary>
    public Guid CartId { get; set; }


    /// <summary>
    /// Initializes a new instance of the Carts class.
    /// </summary>
    public Products()
    {
        CreatedAt = DateTime.UtcNow;
    }
}