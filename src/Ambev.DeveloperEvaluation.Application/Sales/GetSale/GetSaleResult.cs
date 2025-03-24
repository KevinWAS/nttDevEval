using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }

    public List<ProductsResult.Products> Products { get; set; } = new List<ProductsResult.Products>();

    public GetSaleResult(Carts cart)
    {
        GetSaleResult result = this;
        this.Id = cart.Id;
        this.UserId = cart.UserId;
        this.Date = cart.Date;

        foreach (var prod in cart.Products)
        {
            this.Products.Add(new ProductsResult.Products(prod.Id, prod.RatingCount ?? 1));
        }
    }
}
