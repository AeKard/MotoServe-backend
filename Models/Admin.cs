using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? Username { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public virtual ICollection<AdminAccount> AdminAccounts { get; set; } = new List<AdminAccount>();
}
