using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for Creating a cart sale
/// </summary>
public record CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }

    public List<Application.Sales.ProductsResult.Products> Products { get; set; } = new List<Application.Sales.ProductsResult.Products>();

    public Carts ToEntity()
    {
        return new Carts
        {
            Id = Id,
            UserId = UserId,
            Date = Date,
            Products = Products.Select(p => new Products
            {
                Id = p.ProductId
            }).ToList()
        };
    }
}
