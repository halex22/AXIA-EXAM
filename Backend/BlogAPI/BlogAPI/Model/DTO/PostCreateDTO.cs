using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Model.DTO
{
    public class PostCreateDTO
    {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Post must not be empty")]
        public string Body { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
