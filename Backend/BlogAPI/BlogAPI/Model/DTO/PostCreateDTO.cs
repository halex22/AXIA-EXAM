using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Model.DTO
{
    public class PostCreateDTO
    {
        [Required(ErrorMessage ="Title is required")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 chars long")]
        [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Post must not be empty")]
        [MinLength(20, ErrorMessage = "Post body must be at least 20 characters long")]
        public string Body { get; set; } = null!;
    }
}
