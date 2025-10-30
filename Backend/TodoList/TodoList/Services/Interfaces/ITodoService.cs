using TodoList.Mode;
using TodoList.Mode.DTO;

namespace TodoList.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoDTO>> GetAllTodos();
        public Task<TodoDTO> CreateNewTodo(TodoCreateDTO rawTodo);
        public Task DeleteTodo(int id);
        public Task<IEnumerable<TodoDTO>> GetTodosByCategory(int categoryId);
    }
}
