using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Handler for processing GetUsersCommand requests
/// </summary>
public class GetUsersHandler : IRequestHandler<GetUsersCommand, GetUsersResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetUsersHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUsersCommand request
    /// </summary>
    /// <param name="request">The GetUserscommand</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    public async Task<GetUsersResult> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAllAsync(cancellationToken);
        if (user == null)
            throw new FileNotFoundException($"No users in the database");

        return _mapper.Map<GetUsersResult>(user);
    }
}
