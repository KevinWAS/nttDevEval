using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing Sales operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UsersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //Gets All Carts
    //Gets Single Cart by ID
    //Creates a new Cart
    //Updates a Cart with products
    //Deletes a Cart

    //Gets All Products
    //Gets All Products from a single Cart
    //Creates a new Product
    //Updates a Product
    //Deletes a Product

    /// <summary>
    /// Retrieves all users
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCarts(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetSalesCommand(), cancellationToken);

        return Ok(new ApiResponseWithData<GetSalesResult>
        {
            Success = true,
            Message = "Users retrieved successfully",
            Data = response
        });
    }
}
