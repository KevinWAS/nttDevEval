namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale cart to delete
    /// </summary>
    public Guid Id { get; set; }
}
