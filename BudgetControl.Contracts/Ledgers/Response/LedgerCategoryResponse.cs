namespace BudgetControl.Contracts.Ledgers.Response;

public record LedgerCategoryResponse(Guid Id,
                                     string Name,
                                     float Goal,
                                     string Color,
                                     List<CategoryGroupResponse> Groups);