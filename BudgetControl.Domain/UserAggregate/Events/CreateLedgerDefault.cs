using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.UserAggregate.Events;

public record CreateLedgerDefault(User User) : IDomainEvent;