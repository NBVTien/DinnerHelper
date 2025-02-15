using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Menu.ValueObjects;

namespace DinnerHelper.Domain.Menu.Entities;

public class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

    public string Name { get; }
    public string Description { get; }
}