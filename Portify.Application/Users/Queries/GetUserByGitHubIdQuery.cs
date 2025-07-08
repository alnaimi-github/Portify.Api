using MediatR;
using Portify.Domain.Entities;
using ErrorOr;

namespace Portify.Application.Users.Queries;

public record GetUserByGitHubIdQuery(int GitHubId) : IRequest<ErrorOr<User>>;
