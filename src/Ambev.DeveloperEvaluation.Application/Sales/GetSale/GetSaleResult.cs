using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public struct Products
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Products(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetSaleResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }

    public List<Products> Products { get; set; } = new List<Products>();

    public GetSaleResult(Carts cart)
    {
        GetSaleResult result = this;
        this.Id = cart.Id;
        this.UserId = cart.UserId;
        this.Date = cart.Date;

        foreach (var prod in cart.Products)
        {
            this.Products.Add(new Products(prod.Id, prod.RatingCount ?? 1));
        }
    }
}
