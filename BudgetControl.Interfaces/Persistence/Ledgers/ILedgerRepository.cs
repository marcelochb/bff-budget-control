namespace BudgetControl.Interfaces.Persistence.Ledgers;

public interface ILedgerRepository<T>
{
    T? GetLedgerById(string id);
    bool GetLedgerByName(string name);
    void Add(T ledger);
    void Update(T ledger);
    void Remove(string id);
    List<T> GetLedgersByUserId(string userId);
}