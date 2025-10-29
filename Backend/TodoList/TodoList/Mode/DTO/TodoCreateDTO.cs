namespace TodoList.Mode.DTO
{
    public class TodoCreateDTO
    {
        public string Title { get; set; } = null!;

        public int? CategoryId { get; set; }

    }
}
