using DinnerHelper.Domain.Bill.ValueObjects;
using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Dinner.ValueObjects;
using DinnerHelper.Domain.Guest.Entities;
using DinnerHelper.Domain.Guest.ValueObjects;
using DinnerHelper.Domain.MenuReview.ValueObjects;
using DinnerHelper.Domain.User.ValueObjects;

namespace DinnerHelper.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<BillId> _billIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];
    private readonly List<GuestRating> _ratings = [];
    
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    private Guest(GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId)
    {
        return new Guest(GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }
}