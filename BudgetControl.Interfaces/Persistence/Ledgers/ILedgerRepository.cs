namespace BudgetControl.Interfaces.Persistence.Ledgers;

public interface ILedgerRepository<T>
{
    T? GetById(string id);
    bool GetByName(string name);
    void Add(T ledger);
    void Update(T ledger);
    void Remove(string id);
    List<T> GetLedgersByUserId(string userId);
}