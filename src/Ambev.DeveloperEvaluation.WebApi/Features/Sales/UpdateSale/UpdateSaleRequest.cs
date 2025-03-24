namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to update a Cart in the system.
/// </summary>
public class UpdateSaleRequest
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }

    public List<Application.Sales.ProductsResult.Products> Products { get; set; } = new List<Application.Sales.ProductsResult.Products>();
}