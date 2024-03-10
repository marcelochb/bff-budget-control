namespace BudgetControl.Interfaces.Persistence.Categories;

public interface ICategoryRepository<T>
{
    Task<T?> GetById(Guid ledgerId, Guid id);
    Task<bool> GetByName(Guid ledgerId, string name);
    Task Add(Guid ledgerId, T category);
    Task Update(Guid ledgerId, T category);
    Task Remove(Guid ledgerId, Guid id);
    Task<List<T>> GetList(Guid ledgerId);
}
