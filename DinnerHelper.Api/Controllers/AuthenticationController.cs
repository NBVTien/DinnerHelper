using DinnerHelper.Application.Authentication.Commands.Register;
using DinnerHelper.Application.Authentication.Queries.Login;
using DinnerHelper.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    
    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _sender.Send(command);
        
        return authResult.MatchFirst( 
            result => Ok(_mapper.Map<AuthenticateResponse>(result)),
            error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _sender.Send(query);

        return authResult.MatchFirst(
            result => Ok(_mapper.Map<AuthenticateResponse>(result)),
            error => Problem(statusCode: StatusCodes.Status401Unauthorized, title: error.Description));
    }
}