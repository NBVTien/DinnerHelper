using DinnerHelper.Application.Common.Interfaces.Authentication;
using DinnerHelper.Application.Common.Interfaces.Persistence;
using DinnerHelper.Domain.Common.Errors;
using DinnerHelper.Domain.Entities;
using ErrorOr;

namespace DinnerHelper.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public ErrorOr<AuthenticationResult> Login(string username, string password)
    {
        if (_userRepository.GetUserByEmail(username) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredential;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }
}