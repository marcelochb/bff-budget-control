using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Categories;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository<LedgerCategory>
{


    public LedgerCategory? GetById(string ledgerId, string id)
    {
        var ledger = LedgerRepository.ledgers.SingleOrDefault(c => c.Id.ToString() == ledgerId);
        return ledger?.Categories.SingleOrDefault(c => c.Id.ToString() == id);
    }

    public bool GetByName(string ledgerId, string name)
    {
        var ledger = LedgerRepository.ledgers.SingleOrDefault(c => c.Id.ToString() == ledgerId);
        return ledger?.Categories.Any(c => c.Name == name) ?? false;
    }

    public void Add(string ledgerId, LedgerCategory category)
    {
        var index = LedgerRepository.ledgers.FindIndex(c => c.Id.ToString() == ledgerId);
        LedgerRepository.ledgers[index].Categories.Add(category);

    }

    public void Update(string ledgerId, LedgerCategory category)
    {
        var ledgerIndex = LedgerRepository.ledgers.FindIndex(c => c.Id.ToString() == ledgerId);
        var categoryIndex = LedgerRepository.ledgers[ledgerIndex].Categories.FindIndex(c => c.Id.ToString() == category.Id.ToString());
    }

    public void Remove(string ledgerId, string id)
    {
        var index = LedgerRepository.ledgers.FindIndex(c => c.Id.ToString() == ledgerId);
        LedgerRepository.ledgers[index]
            .Categories.Remove(
                LedgerRepository.ledgers[index].Categories.Single(c => c.Id.ToString() == id)
            );
    }

    public List<LedgerCategory> GetList(string ledgerId)
    {
        return LedgerRepository.ledgers
                    .SingleOrDefault(
                        c => c.Id.ToString() == ledgerId
                    )?.Categories ?? new List<LedgerCategory>();
    }
}
