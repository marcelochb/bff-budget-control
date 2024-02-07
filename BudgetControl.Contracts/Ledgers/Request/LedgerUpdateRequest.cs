namespace BudgetControl.Contracts.Ledgers.Request;

public record LedgerUpdateRequest(string Name,
                                  string Type,
                                  string? UserId);