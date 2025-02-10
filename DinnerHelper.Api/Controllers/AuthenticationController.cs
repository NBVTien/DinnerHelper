using DinnerHelper.Application.Services.Authentication;
using DinnerHelper.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult =
            _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authResult.MatchFirst(
            result => Ok(new AuthenticateResponse(
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token)),
            error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        return authResult.MatchFirst(
            result => Ok(new AuthenticateResponse(
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token)),
            error => Problem(statusCode: StatusCodes.Status401Unauthorized, title: error.Description));
    }
}