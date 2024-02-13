namespace BudgetControl.Interfaces.Persistence.Categories;

public interface ICategoryRepository<T>
{
    T? GetById(string ledgerId, string id);
    bool GetByName(string ledgerId, string name);
    void Add(string ledgerId, T category);
    void Update(string ledgerId, T category);
    void Remove(string ledgerId, string id);
    List<T> GetList(string ledgerId);
}
