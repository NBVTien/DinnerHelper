using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }
    
    private MenuId(Guid value)
    {
        Value = value;
    }
    
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}