namespace BudgetControl.Contracts.Groups.Request;

public record CategoryGroupCreateRequest(string Name,
                                               float Goal);