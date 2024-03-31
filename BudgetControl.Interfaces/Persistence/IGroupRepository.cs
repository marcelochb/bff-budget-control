namespace BudgetControl.Interfaces.Persistence;

public interface IGroupRepository<T>
{
    T? GetById(string ledgerId,
               string categoryId,
               string id);
    bool GetByName(string ledgerId,
                   string categoryId,
                   string name);
    void Add(string ledgerId,
             string categoryId,
             T group);
    void Update(string ledgerId,
                string categoryId,
                T group);
    void Remove(string ledgerId,
                string categoryId,
                string id);
    List<T> GetList(string ledgerId,
                    string categoryId,
                    string userId);
}
