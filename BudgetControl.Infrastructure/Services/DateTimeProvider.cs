using BudgetControl.Interfaces.Persistence.Authentication;

namespace BudgetControl.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}