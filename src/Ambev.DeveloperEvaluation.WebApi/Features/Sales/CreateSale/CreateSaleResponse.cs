using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Response model for CreateSale operation
/// </summary>
public class CreateSaleResponse : GetSaleResult
{
    public CreateSaleResponse(Carts cart) : base(cart)
    {
    }
}
