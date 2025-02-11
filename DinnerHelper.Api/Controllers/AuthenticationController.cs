using DinnerHelper.Application.Authentication.Commands.Register;
using DinnerHelper.Application.Authentication.Queries.Login;
using DinnerHelper.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;
    
    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }
    
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var authResult = await _sender.Send(command);
        
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
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _sender.Send(query);

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