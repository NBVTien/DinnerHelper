using DinnerHelper.Domain.User;

namespace DinnerHelper.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}