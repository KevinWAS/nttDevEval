namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Represents a request to create a new Cart in the system.
/// </summary>
public class CreateSaleRequest
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }

    public List<Application.Sales.ProductsResult.Products> Products { get; set; } = new List<Application.Sales.ProductsResult.Products>();
}