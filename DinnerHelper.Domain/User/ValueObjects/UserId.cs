using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }
    
    private UserId(Guid value)
    {
        Value = value;
    }
    
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}