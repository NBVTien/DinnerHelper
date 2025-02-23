using DinnerHelper.Domain.Menu;

namespace DinnerHelper.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}