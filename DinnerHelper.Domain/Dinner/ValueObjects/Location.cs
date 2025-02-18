using DinnerHelper.Domain.Common.Models;

namespace DinnerHelper.Domain.Dinner.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }
    public float Latitude { get; }
    public float Longitude { get; }
    
    public Location(string name, string address, float latitude, float longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}