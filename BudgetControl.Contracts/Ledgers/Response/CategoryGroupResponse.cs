namespace BudgetControl.Contracts.Ledgers.Response;

public record CategoryGroupResponse(Guid Id,
                                    string Name,
                                    float Goal);
