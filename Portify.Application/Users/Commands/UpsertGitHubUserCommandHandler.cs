using ErrorOr;
using Mapster;
using MediatR;
using Portify.Domain.Entities;
using Portify.Application.Interfaces;

namespace Portify.Application.Users.Commands;

public class UpsertGitHubUserCommandHandler(IUserService userService)
    : IRequestHandler<UpsertGitHubUserCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(UpsertGitHubUserCommand request, CancellationToken cancellationToken)
    {
        User userEntity = request.GitHubUser.Adapt<User>();
        ErrorOr<User> result = await userService.UpsertGitHubUserAsync(userEntity);

        if (result.IsError)
        {
            return result.Errors;
        }

        return userEntity.Id;
    }
}
