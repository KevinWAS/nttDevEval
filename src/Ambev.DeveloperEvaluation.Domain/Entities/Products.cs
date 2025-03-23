using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a Cart in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Products : BaseEntity
{
    /// <summary>
    /// UserId owner of the cart
    /// </summary>
    public Carts Carts { get; set; }

    /// <summary>
    /// Date of the cart
    /// </summary>
    public string? Title { get; set; }

    public float? Price { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Image { get; set; }

    public float? RatingRate { get; set; }

    public int? RatingCount { get; set; }

    /// <summary>
    /// Gets the date and time when the cart was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the Cart's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the Carts class.
    /// </summary>
    public Products()
    {
        CreatedAt = DateTime.UtcNow;
    }
}