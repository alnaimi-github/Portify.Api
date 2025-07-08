using MediatR;
using Portify.Domain.Entities;
using ErrorOr;
using Portify.Application.Interfaces;

namespace Portify.Application.Users.Queries;

public class GetUserByGitHubIdQueryHandler(IUserService userService)
    : IRequestHandler<GetUserByGitHubIdQuery, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetUserByGitHubIdQuery request, CancellationToken cancellationToken)
    {
        // ReSharper disable once ArrangeMethodOrOperatorBody
        return await userService.GetByGitHubIdAsync(request.GitHubId);
    }
}
