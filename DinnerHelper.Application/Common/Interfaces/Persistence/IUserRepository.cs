using DinnerHelper.Domain.Entities;

namespace DinnerHelper.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}