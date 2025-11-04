using System;
using System.Collections.Generic;

namespace ContactsAPI.Model;

public partial class Contact
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<GroupContact> GroupContacts { get; set; } = new List<GroupContact>();
}
