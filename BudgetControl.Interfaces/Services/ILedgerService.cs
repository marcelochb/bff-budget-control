using ErrorOr;

namespace BudgetControl.Interfaces.Services;

public interface ILedgerService<T>
{
    ErrorOr<T> Create(T Ledger);
    ErrorOr<T> Update(T Ledger);
    ErrorOr<T> Delete(string LedgerId);
    ErrorOr<T> Get(string LedgerId);
    ErrorOr<List<T>> GetList();
}