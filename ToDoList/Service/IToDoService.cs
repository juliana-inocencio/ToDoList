namespace ToDoList.Service;

public interface IToDoService
{
    Task<IEnumerable<ToDoItem>> GetAllAsync();
    Task<ToDoItem> GetByIdAsync(int id);
    Task AddAsync(ToDoItem toDoItem);
    Task UpdateAsync(ToDoItem toDoItem);
    Task DeleteAsync(int id);
}
