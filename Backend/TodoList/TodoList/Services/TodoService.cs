using Microsoft.EntityFrameworkCore;
using TodoList.Mode;
using TodoList.Mode.DTO;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<TodoDTO> CreateNewTodo(TodoCreateDTO rawTodo)
        {
            if (String.IsNullOrWhiteSpace(rawTodo.Title))
            {
                throw new ArgumentNullException($"{nameof(rawTodo.Title)} must be given a value");
            }

            Todo todoToAdd = new Todo
            {
                Title = rawTodo.Title,
                CategoryId = rawTodo.CategoryId ?? 10,
            };

            _context.Todos.Add(todoToAdd);
            await _context.SaveChangesAsync();

            return ConvertTodo(todoToAdd);

        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            if (todo == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<TodoDTO>> GetAllTodos()
        {
            var result = await _context.Todos.Include( t => t.Category).ToListAsync();
            return result.Select( t => ConvertTodo(t));
        }

        public async Task<IEnumerable<TodoDTO>> GetTodosByCategory(int categoryId)
        {
            IQueryable<Todo> query = _context.Todos.AsQueryable();
            query = query.Where( t => t.CategoryId == categoryId);
            var result = await query.Include( t => t.Category).ToListAsync();
            return result.Select( t => ConvertTodo(t)) ;
        }

        public TodoDTO ConvertTodo(Todo todo)
        {
            return new TodoDTO
            {
                Id = todo.Id,
                Category = todo.Category,
                Completed = todo.Completed,
                CreatedAt = todo.CreatedAt,
                Title = todo.Title,
            };
        }

        //public Todo CompleteNewTodo(TodoCreateDTO todo)
        //{
        //    return new Todo
        //    {
        //        Title = todo.Title,
        //        CategoryId = todo.CategoryId ?? 10,
        //    };
        //}
    }
}
