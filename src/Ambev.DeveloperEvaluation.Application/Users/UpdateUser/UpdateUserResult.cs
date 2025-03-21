using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully updating an user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the updated user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateUserResult : User
{
}
