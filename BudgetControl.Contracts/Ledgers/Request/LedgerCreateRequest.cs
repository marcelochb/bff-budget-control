namespace BudgetControl.Contracts.Ledgers.Request;

public record LedgerCreateRequest(string Name,
                                  string Type,
                                  List<LedgerCategoryCreateRequest> Categories);