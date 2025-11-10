namespace BlogAPI.Model.DTO
{
    public class CommentCreateDTO
    {
        public int? PostId { get; set; }

        public string Author { get; set; } = null!;

        public string? Content { get; set; }
    }
}
