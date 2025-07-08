using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Portify.Infrastructure.Services;
using Portify.Infrastructure.Configuration.Settings;
using Portify.Shared.DTOs;
using Portify.Shared.DTOs.Responses;
using Mapster;
using MediatR;
using Portify.Application.Interfaces;
using Portify.Application.Users.Commands;
using ErrorOr;

namespace Portify.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(
    GitHubOAuthService gitHubOAuthService,
    IJwtService jwtService,
    IOptions<GitHubOAuthConfig> config,
    IMediator mediator)
    : ControllerBase
{
    [HttpGet("github-login")]
    [ProducesResponseType(typeof(void), 302)]
    public IActionResult GitHubLogin([FromQuery] string state)
    {
        string url = gitHubOAuthService.GetAuthorizationUrl(state);
        return Redirect(url);
    }

    [HttpGet("github/callback")]
    [ProducesResponseType(typeof(ErrorOr<AppUserResponse>), 200)]
    [ProducesResponseType(typeof(ErrorOr<string>), 400)]
    public async Task<IActionResult> GitHubCallback([FromQuery] string code, [FromQuery] string state)
    {
        string accessToken = await gitHubOAuthService.ExchangeCodeForTokenAsync(code);
        GitHubUserDto gitHubUser = await gitHubOAuthService.GetUserAsync(accessToken);

        Guid userGuid = GuidUtility.Create(GuidUtility.UrlNamespace, $"github-{gitHubUser.Id}");
        ErrorOr<Guid> upsertResult = await mediator.Send(new UpsertGitHubUserCommand(gitHubUser));
        if (upsertResult.IsError)
        {
            return BadRequest(Error.Failure(upsertResult.FirstError.Description));
        }

        string jwt = jwtService.GenerateToken(upsertResult.Value, gitHubUser.Email, []);
        AppUserResponse userResponse = gitHubUser.Adapt<AppUserResponse>() with { Token = jwt };
        Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true, Secure = true });
        return Ok(userResponse);
    }

    [HttpPost("logout")]
    [ProducesResponseType(typeof(ErrorOr<string>), 200)]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok("Logged out successfully.");
    }
}
