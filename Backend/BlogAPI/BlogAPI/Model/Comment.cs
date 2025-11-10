using System;
using System.Collections.Generic;

namespace BlogAPI.Model;

public partial class Comment
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public string Author { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Post? Post { get; set; }
}
