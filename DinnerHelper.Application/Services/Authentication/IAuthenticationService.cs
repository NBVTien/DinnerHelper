using ErrorOr;

namespace DinnerHelper.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string username, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}