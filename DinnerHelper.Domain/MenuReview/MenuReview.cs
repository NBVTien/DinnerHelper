using DinnerHelper.Domain.Common.Models;
using DinnerHelper.Domain.Dinner.ValueObjects;
using DinnerHelper.Domain.Guest.ValueObjects;
using DinnerHelper.Domain.Host.ValueObjects;
using DinnerHelper.Domain.Menu.ValueObjects;
using DinnerHelper.Domain.MenuReview.ValueObjects;

namespace DinnerHelper.Domain.MenuReview;

// NOTE: MenuReview is done, for now.
public class MenuReview : AggregateRoot<MenuReviewId>
{
    public float Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    private MenuReview(
        MenuReviewId id,
        float rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static MenuReview Create(
        float rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new MenuReview(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}