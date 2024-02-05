namespace BudgetControl.Contracts.Ledgers.Request;

public record CategoryGroupCreateRequest(string Name,
                                               float Goal);