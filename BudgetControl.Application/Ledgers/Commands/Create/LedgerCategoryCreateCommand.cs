namespace BudgetControl.Application.Ledgers.Commands.Create;

public record LedgerCategoryCreateCommand(string Name,
                                          float Goal,
                                          string Color,
                                          List<CategoryGroupCreateCommand> Groups
                                          );