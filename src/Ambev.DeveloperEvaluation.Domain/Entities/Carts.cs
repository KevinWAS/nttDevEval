using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a Cart in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Carts : BaseEntity
{
    /// <summary>
    /// UserId owner of the cart
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Date of the cart
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// List of products on this cart
    /// </summary>
    //public List<Products>? Products { get; set; }

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
    public Carts()
    {
        CreatedAt = DateTime.UtcNow;
    }
}