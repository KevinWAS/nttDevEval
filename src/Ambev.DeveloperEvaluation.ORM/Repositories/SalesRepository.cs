﻿using Ambev.DeveloperEvaluation.Domain.Entities;
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
    /// Retrieves all carts
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users if found, null otherwise</returns>
    public async Task<List<Carts>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Carts.Include(u=>u.Products).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<Carts?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Creates a new cart in the repository
    /// </summary>
    /// <param name="user">The cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart</returns>
    public async Task<Carts> CreateCartAsync(Carts cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Updates an sale cart in the database
    /// </summary>
    /// <param name="user">The cart to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated cart</returns>
    public async Task<Carts> UpdateCartAsync(Carts cart, CancellationToken cancellationToken = default)
    {
        cart.UpdatedAt = DateTime.UtcNow;
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }
    public async Task<bool> CheckIfProductsExist(List<Guid> productIds)
    {
        var existingProductIds = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync();

        return productIds.All(id => existingProductIds.Contains(id));
    }

    public async Task<int> AssignCartId(Guid cartId, List<Guid> productIds, CancellationToken cancellationToken = default)
    {
        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        foreach (var product in products)
        {
            product.CartsId = cartId;
        }
        _context.Products.UpdateRange(products);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a sale cart from the database
    /// </summary>
    /// <param name="id">The unique identifier of the cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the cart was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
