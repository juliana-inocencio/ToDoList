namespace ToDoList.Repository;

public interface IToDoRepository
{
    Task<IEnumerable<ToDoItem>> GetAllAsync();
    Task<ToDoItem> GetByIdAsync(int id);
    Task<ToDoItem> GetByTituloAsync(string titulo);
    Task AddAsync(ToDoItem toDoItem);
    Task UpdateAsync(ToDoItem toDoItem);
    Task DeleteAsync(int id);
}
