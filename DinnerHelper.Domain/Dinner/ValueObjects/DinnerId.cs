using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }
    
    private DinnerId(Guid value)
    {
        Value = value;
    }
    
    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}