namespace TodoList.Mode.DTO
{
    public class TodoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool? Completed { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }
}
