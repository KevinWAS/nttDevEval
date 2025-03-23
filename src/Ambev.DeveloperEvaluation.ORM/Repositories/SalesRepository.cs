using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class SalesRepository : ISalesRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SalesRepository(DefaultContext context)
    {
        _context = context;
        _context.Database.Migrate();
    }

    /// <summary>
    /// Retrieves all users
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users if found, null otherwise</returns>
    public async Task<List<Carts>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Carts.ToListAsync(cancellationToken);
    }
}
