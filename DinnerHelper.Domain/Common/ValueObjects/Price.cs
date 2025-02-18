using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}