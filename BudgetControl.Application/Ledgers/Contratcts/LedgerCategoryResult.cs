namespace BudgetControl.Application.Ledgers.Contratcts;

public record LedgerCategoryResult(Guid Id,
                             string Name,
                             float Goal,
                             string Color,
                             List<CategoryGroupResult> Groups);