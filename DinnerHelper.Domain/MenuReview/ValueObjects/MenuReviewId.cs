using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    
    private MenuReviewId(Guid value)
    {
        Value = value;
    }
    
    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}