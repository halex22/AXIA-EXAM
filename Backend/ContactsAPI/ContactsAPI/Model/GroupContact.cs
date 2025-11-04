using System;
using System.Collections.Generic;

namespace ContactsAPI.Model;

public partial class GroupContact
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? ContactId { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual Group? Group { get; set; }
}
