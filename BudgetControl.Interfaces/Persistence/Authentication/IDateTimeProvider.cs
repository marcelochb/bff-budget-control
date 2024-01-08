namespace BudgetControl.Interfaces.Persistence.Authentication;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
};