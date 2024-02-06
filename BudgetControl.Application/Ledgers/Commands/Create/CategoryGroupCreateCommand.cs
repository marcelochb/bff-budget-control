namespace BudgetControl.Application.Ledgers.Commands.Create;

public record CategoryGroupCreateCommand(string Name,
                                         float Goal);