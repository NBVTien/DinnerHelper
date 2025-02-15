using DinnerHelper.Domain.User;

namespace DinnerHelper.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    public string GenerateToken(User user);
}