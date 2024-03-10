namespace BudgetControl.Interfaces.Persistence.Ledgers;

public interface ILedgerRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<bool> GetByName(string name);
    Task Add(T ledger);
    Task Update(T ledger);
    Task Remove(Guid id);
    List<T> GetLedgersByUserId(Guid userId);
}