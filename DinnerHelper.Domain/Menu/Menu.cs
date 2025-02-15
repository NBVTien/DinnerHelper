using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Dinner.ValueObjects;
using DinnerHelper.Domain.Host.ValueObjects;
using DinnerHelper.Domain.Menu.Entities;
using DinnerHelper.Domain.Menu.ValueObjects;
using DinnerHelper.Domain.MenuReview.ValueObjects;

namespace DinnerHelper.Domain.Menu;

// NOTE: Menu is done, for now.
public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];
    
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    private Menu(
        MenuId id,
        string name,
        string description,
        float averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = averageRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static Menu Create(
        string name,
        string description,
        float averageRating,
        HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}