using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface ISalesRepository
{
    /// <summary>
    /// Retrieves all users
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users if found, null otherwise</returns>
    public Task<List<Carts>?> GetAllAsync(CancellationToken cancellationToken = default);
}
