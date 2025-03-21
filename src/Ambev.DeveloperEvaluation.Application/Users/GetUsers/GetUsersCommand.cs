using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Command for retrieving all users
/// </summary>
public record GetUsersCommand : IRequest<GetUsersResult>
{
}
