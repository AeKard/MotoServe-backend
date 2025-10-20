using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Receptionist
{
    public int ReceptionistId { get; set; }

    public string? Username { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public virtual ICollection<ReceptionistAccount> ReceptionistAccounts { get; set; } = new List<ReceptionistAccount>();
}
