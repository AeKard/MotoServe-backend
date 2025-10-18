using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class ReceptionistAccount
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? ReceptionistId { get; set; }
}
