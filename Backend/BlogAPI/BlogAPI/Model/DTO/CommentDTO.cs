namespace BlogAPI.Model.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        public string Author { get; set; } = null!;

        public string? Content { get; set; }

        public DateTime? CreatedAt { get; set; }

        // public virtual PostDTO? Post { get; set; }
    }
}
