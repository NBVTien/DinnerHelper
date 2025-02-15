using DinnerHelper.Application.Common.Interfaces.Authentication;
using DinnerHelper.Application.Common.Interfaces.Persistence;
using DinnerHelper.Application.Services.Authentication;
using DinnerHelper.Domain.Common.Errors;
using DinnerHelper.Domain.User;
using MediatR;
using ErrorOr;

namespace DinnerHelper.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // TODO: Hash password
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);
        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);    
    }
}