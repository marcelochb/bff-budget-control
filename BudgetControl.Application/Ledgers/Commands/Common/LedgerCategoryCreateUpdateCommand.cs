namespace BudgetControl.Application.Ledgers.Commands.Common;

public record LedgerCategoryCreateUpdateCommand(string Name,
                                          float Goal,
                                          string Color,
                                          List<CategoryGroupCreateUpdateCommand> Groups
                                          );