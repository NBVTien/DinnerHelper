using DinnerHelper.Application.Common.Interfaces.Persistence;
using DinnerHelper.Domain.Menu;

namespace DinnerHelper.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];
    
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}