using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Handler for processing GetUsersCommand requests
/// </summary>
public class GetSalesHandler : IRequestHandler<GetSalesCommand, GetSalesResult>
{
    private readonly ISalesRepository _salesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetUsersHandler
    /// </summary>
    /// <param name="salesRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetSalesHandler(
        ISalesRepository salesRepository,
        IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUsersCommand request
    /// </summary>
    /// <param name="request">The GetUserscommand</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    //public async Task<GetSalesResult> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    public async Task<GetSalesResult> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        var sales = await _salesRepository.GetAllAsync(cancellationToken);
        if (sales == null)
            throw new FileNotFoundException($"No sales in the database");

        return new GetSalesResult(sales);
    }
}
