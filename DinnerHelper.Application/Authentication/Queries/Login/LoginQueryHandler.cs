using DinnerHelper.Application.Common.Interfaces.Authentication;
using DinnerHelper.Application.Common.Interfaces.Persistence;
using DinnerHelper.Application.Services.Authentication;
using DinnerHelper.Domain.Common.Errors;
using DinnerHelper.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerHelper.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredential;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}