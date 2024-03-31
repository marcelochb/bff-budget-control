namespace BudgetControl.Application.Ledgers.Contratcts;


public record LedgerResult(
    Guid Id,
    Guid UserId,
    string Name,
    string Type,
    List<LedgerCategoryResult> Categories);