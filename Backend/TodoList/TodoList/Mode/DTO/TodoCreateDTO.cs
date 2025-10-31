using System.ComponentModel.DataAnnotations;

namespace TodoList.Mode.DTO
{
    public class TodoCreateDTO
    {
        [Required(ErrorMessage = "Title is required")] // send a 400 Bad Request automatically 
        public string Title { get; set; } 

        public int? CategoryId { get; set; }

    }
}
