using System;
using System.Collections.Generic;

namespace ContactsAPI.Model;

public partial class Group
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<GroupContact> GroupContacts { get; set; } = new List<GroupContact>();
}
