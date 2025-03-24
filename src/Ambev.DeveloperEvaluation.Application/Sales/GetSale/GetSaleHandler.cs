using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISalesRepository _salesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleHandler
    /// </summary>
    /// <param name="salesRepository">The Sales repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetSaleHandler(
        ISalesRepository salesRepository,
        IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleCommand request
    /// </summary>
    /// <param name="request">The GetSaleCommand</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sales = await _salesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sales == null)
            throw new FileNotFoundException($"No sales in the database");

        return new GetSaleResult(sales);
    }
}
