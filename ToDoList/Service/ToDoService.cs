using ToDoList.Repository;

namespace ToDoList.Service
{
    public class ToDoService:IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _toDoRepository.GetAllAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _toDoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ToDoItem toDoItem)
        {
            var existingItem = await _toDoRepository.GetByTituloAsync(toDoItem.Titulo);
            if (existingItem != null)
            {
                throw new Exception("Já existe uma tarefa com este título.");
            }

            await _toDoRepository.AddAsync(toDoItem);
        }

        public async Task UpdateAsync(ToDoItem toDoItem)
        {
            await _toDoRepository.UpdateAsync(toDoItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _toDoRepository.DeleteAsync(id);
        }
    }
}
