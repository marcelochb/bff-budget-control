using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.UserAggregate.Events;

public record UserCreated(User User) : IDomainEvent;