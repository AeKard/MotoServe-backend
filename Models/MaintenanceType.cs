using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class MaintenanceType
{
    public int MaintenanceId { get; set; }

    public string? ListOfMaintenance { get; set; }

    public int? MechanicId { get; set; }
}
