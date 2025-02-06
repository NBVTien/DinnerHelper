using DinnerHelper.Domain.Entities;

namespace DinnerHelper.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);