namespace BudgetControl.Contracts.Categories.Request;

public record CategoryRequest(string Name,
                                float Goal,
                                string Color,
                                string LedgerId);