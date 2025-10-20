using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class MaintenanceType
{
    public int MaintenanceId { get; set; }

    public string? MaintenanceType1 { get; set; }

    public int? MechanicId { get; set; }

    public virtual ICollection<MaintenanceHistory> MaintenanceHistories { get; set; } = new List<MaintenanceHistory>();

    public virtual Mechanic? Mechanic { get; set; }
}
