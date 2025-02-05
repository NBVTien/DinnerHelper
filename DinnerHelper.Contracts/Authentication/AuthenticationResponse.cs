namespace DinnerHelper.Contracts.Authentication;

public record AuthenticateResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);