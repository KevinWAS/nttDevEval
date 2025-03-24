using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISalesRepository _salesRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="salesRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(
        ISalesRepository salesRepository,
        IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateUsersCommand request
    /// </summary>
    /// <param name="request">The CreateSaleCommand</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        // Check if products exist
        var productIds = request.Products.Select(p => p.ProductId).ToList();
        if (request.Products != null && request.Products.Count > 0)
        {
            if (! await _salesRepository.CheckIfProductsExist(productIds))
                throw new FileNotFoundException($"One or more products were not found in the database");
            request.Id = Guid.NewGuid();
        }

        request.Products = new List<ProductsResult.Products>();
        var sale = await _salesRepository.CreateCartAsync(request.ToEntity(), cancellationToken);
        if (sale == null)
            throw new FileNotFoundException($"Error saving this cart sales in the database");
        await _salesRepository.AssignCartId(request.Id, productIds, cancellationToken);

        return new CreateSaleResult(sale);
    }
}
