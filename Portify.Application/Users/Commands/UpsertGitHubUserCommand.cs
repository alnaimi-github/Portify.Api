using Portify.Shared.DTOs;
using MediatR;
using ErrorOr;

namespace Portify.Application.Users.Commands;

public record UpsertGitHubUserCommand(GitHubUserDto GitHubUser) : IRequest<ErrorOr<Guid>>;
