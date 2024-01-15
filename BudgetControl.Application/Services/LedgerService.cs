using BudgetControl.Application.Contratcts;
using BudgetControl.Interfaces.Services;
using ErrorOr;

namespace BudgetControl.Application.Services;

public class LedgerService : ILedgerService<LedgerResult>
{
    public ErrorOr<LedgerResult> Create(LedgerResult Ledger)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<LedgerResult> Delete(string LedgerId)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<LedgerResult> Get(string LedgerId)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<List<LedgerResult>> GetList()
    {
        throw new NotImplementedException();
    }

    public ErrorOr<LedgerResult> Update(LedgerResult Ledger)
    {
        throw new NotImplementedException();
    }
}