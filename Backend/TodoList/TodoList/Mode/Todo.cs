using System;
using System.Collections.Generic;

namespace TodoList.Mode;

public partial class Todo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool? Completed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
