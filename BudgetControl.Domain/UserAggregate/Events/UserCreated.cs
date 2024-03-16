using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.Entities;

namespace BudgetControl.Domain.UserAggregate.Events;

public record UserCreated(User User) : IDomainEvent;