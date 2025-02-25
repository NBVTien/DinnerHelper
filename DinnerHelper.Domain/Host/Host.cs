using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Dinner.ValueObjects;
using DinnerHelper.Domain.Host.ValueObjects;
using DinnerHelper.Domain.Menu.ValueObjects;
using DinnerHelper.Domain.User.ValueObjects;

namespace DinnerHelper.Domain.Host;

// TODO: Host is done, for now.
public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new(); 
    
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    private Host(HostId id,
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
    
    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId)
    {
        return new Host(HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }
}