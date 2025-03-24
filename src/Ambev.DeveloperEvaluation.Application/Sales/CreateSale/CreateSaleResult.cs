using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Response model for CreateSale operation
/// </summary>
public class CreateSaleResult : GetSaleResult
{
    public CreateSaleResult(Carts cart) : base(cart)
    {
    }
}
