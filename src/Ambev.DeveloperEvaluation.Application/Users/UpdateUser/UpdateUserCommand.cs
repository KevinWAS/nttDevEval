﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Command for updating an user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating an user, 
/// including username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateUserResult"/>.
/// </remarks>
public class UpdateUserCommand : IRequest<UpdateUserResult>
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updateduser in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user to be updated.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the user.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address for the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; set; }
}