using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    
    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    
    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}