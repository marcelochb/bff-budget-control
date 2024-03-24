using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.ValueObjects;

namespace BudgetControl.Domain.ConfigAggregate.Events;
public record ConfigCreated(Config Config, User User) : IDomainEvent;