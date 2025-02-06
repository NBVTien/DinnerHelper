using DinnerHelper.Application.Common.Interfaces.Services;

namespace DinnerHelper.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}