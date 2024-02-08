namespace BudgetControl.Contracts.Ledgers.Response;

public record LedgerCategoryResponse(string Id,
                                     string Name,
                                     float Goal,
                                     string Color,
                                     List<CategoryGroupResponse> Groups);