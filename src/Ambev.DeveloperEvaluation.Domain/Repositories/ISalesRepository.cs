using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISalesRepository
{
    /// <summary>
    /// Retrieves all Sales
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of Sales if found, null otherwise</returns>
    public Task<List<Carts>?> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale if found, null otherwise</returns>
    public Task<Carts?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


    /// <summary>
    /// Creates a new cart in the repository
    /// </summary>
    /// <param name="Sale">The cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart</returns>
    Task<Carts> CreateCartAsync(Carts cart, CancellationToken cancellationToken = default);

    Task<Carts> UpdateCartAsync(Carts cart, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);


    Task<bool> CheckIfProductsExist(List<Guid> productIds);

    Task<int> AssignCartId(Guid cartId, List<Guid> productIds, CancellationToken cancellationToken = default);
}
