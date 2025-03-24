using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.ProductsResult;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISalesRepository _salesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="salesRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public UpdateSaleHandler(
        ISalesRepository salesRepository,
        IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="request">The UpdateSalecommand</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        // Check if products exist
        var productIds = request.Products.Select(p => p.ProductId).ToList();
        if (request.Products != null && request.Products.Count > 0)
        {
            if (! await _salesRepository.CheckIfProductsExist(productIds))
                throw new FileNotFoundException($"One or more products were not found in the database");
        }

        request.Products = new List<ProductsResult.Products>();
        var sale = await _salesRepository.UpdateCartAsync(request.ToEntity(), cancellationToken);
        if (sale == null)
            throw new FileNotFoundException($"Error updating cart sale in the database");
        await _salesRepository.AssignCartId(request.Id, productIds, cancellationToken);

        return new UpdateSaleResult(sale);
    }
}
