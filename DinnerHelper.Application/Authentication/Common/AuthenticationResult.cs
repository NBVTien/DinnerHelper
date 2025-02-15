using DinnerHelper.Domain.User;

namespace DinnerHelper.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);