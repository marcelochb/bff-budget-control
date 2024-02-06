namespace BudgetControl.Contracts.Ledgers.Request;

public record LedgerCreateRequest(string Name,
                                  string Type,
                                  string? UserId,
                                  List<LedgerCategoryCreateRequest> Categories);