namespace BudgetControl.Interfaces.Persistence.Categories;

public interface ICategoryRepository<T>
{
    Task<T?> GetById(string ledgerId, string id);
    Task<bool> GetByName(string ledgerId, string name);
    Task Add(string ledgerId, T category);
    Task Update(string ledgerId, T category);
    Task Remove(string ledgerId, string id);
    Task<List<T>> GetList(string ledgerId);
}
