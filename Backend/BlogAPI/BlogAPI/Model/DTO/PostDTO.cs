namespace BlogAPI.Model.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Body { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
