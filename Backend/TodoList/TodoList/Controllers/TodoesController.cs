using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Mode;
using TodoList.Mode.DTO;
using TodoList.Services.Interfaces;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly TodoDbContext _context;
        private readonly ITodoService _todoService;

        public TodoesController(TodoDbContext context, ITodoService todoService)
        {
            _context = context;
            _todoService = todoService;
        }

        // GET: api/Todoes
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var result = await _todoService.GetAllTodos();  
            return Ok(result);
        }
        // GET: api/Todoes/by-category/{id}
        public async Task<IActionResult> GetTodosByCategory(int categoryId)
        {
            var result = await _todoService.GetTodosByCategory(categoryId);
            return Ok(result);
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTodo(TodoCreateDTO newtodo)
        {
            try
            {
                var todo = await _todoService.CreateNewTodo(newtodo);
                return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "A concurrency error occurred while saving the Todo." });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                await _todoService.DeleteTodo(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
