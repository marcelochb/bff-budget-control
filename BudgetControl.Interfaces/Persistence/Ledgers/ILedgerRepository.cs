namespace BudgetControl.Interfaces.Persistence.Ledgers;

public interface ILedgerRepository<T>
{
    Task<T?> GetById(string id);
    Task<bool> GetByName(string name);
    Task Add(T ledger);
    Task Update(T ledger);
    Task Remove(string id);
    List<T> GetLedgersByUserId(string userId);
}