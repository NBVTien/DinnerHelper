using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Guest.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }
    
    private GuestRatingId(Guid value)
    {
        Value = value;
    }
    
    public static GuestRatingId CreateUnique()
    {
        return new GuestRatingId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}