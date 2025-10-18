using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class MaintenanceHistory
{
    public int Id { get; set; }

    public int? MotorcycleId { get; set; }

    public int? MechanicId { get; set; }

    public int? CustomerId { get; set; }

    public int? MaintenanceId { get; set; }

    public int? ScheduleId { get; set; }
}
