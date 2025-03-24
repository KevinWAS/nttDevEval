using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Command for retrieving all users
/// </summary>
public record GetSalesCommand : IRequest<GetSalesResult>
{
}
