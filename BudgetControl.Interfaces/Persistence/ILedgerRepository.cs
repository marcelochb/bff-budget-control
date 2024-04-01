namespace BudgetControl.Interfaces.Persistence;

public interface ILedgerRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<bool> GetByName(string name);
    Task Add(T ledger);
    Task Update(T ledger);
    Task Remove(Guid id);
    Task<List<T>> GetLedgersByUserId(Guid userId);
}