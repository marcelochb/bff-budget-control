
using BudgetControl.Domain.LedgerAggregate;

namespace BudgetControl.Application.Ledgers.Contratcts;

public record LedgerListResult(List<Ledger> Items);