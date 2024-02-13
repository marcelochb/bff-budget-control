namespace BudgetControl.Contracts.Ledgers.Request;

public record LedgerRequest(string Name,
                                  string Type,
                                  string? UserId);