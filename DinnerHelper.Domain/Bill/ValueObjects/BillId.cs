using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Bill.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }
    
    private BillId(Guid value)
    {
        Value = value;
    }
    
    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}