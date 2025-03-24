using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetSalesResult : List<GetSaleResult>
{
    public GetSalesResult(List<Carts> carts)
    {
        foreach (var cart in carts)
        {
            this.Add(new GetSaleResult(cart));
        }
    }
}
