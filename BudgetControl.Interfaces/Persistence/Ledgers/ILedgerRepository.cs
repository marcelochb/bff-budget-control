namespace BudgetControl.Interfaces.Persistence.Ledgers;

public interface ILedgerRepository<T>
{
    T? GetLedgerById(string id);
    void Add(T ledger);
    void Update(T ledger);
    void Remove(string id);
    List<T> GetLedgersByUserId(string userId);
}