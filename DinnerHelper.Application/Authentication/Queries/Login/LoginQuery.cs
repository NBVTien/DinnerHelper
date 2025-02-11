using DinnerHelper.Application.Services.Authentication;
using ErrorOr;
using MediatR;

namespace DinnerHelper.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;