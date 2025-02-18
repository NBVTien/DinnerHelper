using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Dinner.ValueObjects;
using DinnerHelper.Domain.Guest.ValueObjects;
using DinnerHelper.Domain.Host.ValueObjects;

namespace DinnerHelper.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public float Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    private GuestRating(
        GuestRatingId id,
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        float rating)
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}