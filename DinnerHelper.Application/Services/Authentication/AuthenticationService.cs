using DinnerHelper.Application.Common.Interfaces.Authentication;

namespace DinnerHelper.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Login(string username, string password)
    {
        // TODO: Check if the user exists
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, "firstName", "lastName");

        return new AuthenticationResult(
            userId,
            "firstName",
            "lastName",
            "email",
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // TODO: Check if the user exists
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }
}