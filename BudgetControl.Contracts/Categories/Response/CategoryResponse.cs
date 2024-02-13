namespace BudgetControl.Contracts.Categories.Response;

public record CategoryResponse(string Name,
                                     float Goal,
                                     string Color);