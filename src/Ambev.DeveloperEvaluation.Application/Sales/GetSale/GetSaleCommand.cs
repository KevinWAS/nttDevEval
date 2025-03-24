using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a single cart sale
/// </summary>
public record GetSaleCommand : IRequest<GetSaleResult>
{
    public GetSaleCommand(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// The unique identifier of the Cart to retrieve
    /// </summary>
    public Guid Id { get; }
}
