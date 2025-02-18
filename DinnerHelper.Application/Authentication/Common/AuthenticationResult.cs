using DinnerHelper.Domain.User;

namespace DinnerHelper.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);