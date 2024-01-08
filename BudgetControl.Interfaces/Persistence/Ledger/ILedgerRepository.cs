namespace BudgetControl.Interfaces.Persistence.Ledger;

public interface ILedgerRepository<T> {
    T? GetLedgerByName(string name);
    void Add(T ledger);
    void Update(string id, T ledger);
    void Remove(string id);
}