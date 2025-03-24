namespace Ambev.DeveloperEvaluation.Application.Sales.ProductsResult;

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
