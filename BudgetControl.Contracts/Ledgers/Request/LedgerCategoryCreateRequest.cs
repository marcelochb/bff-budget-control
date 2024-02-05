namespace BudgetControl.Contracts.Ledgers.Request;

public record LedgerCategoryCreateRequest(string Name,
                                          float Goal,
                                          string Color,
                                          CategoryGroupCreateRequest groups);