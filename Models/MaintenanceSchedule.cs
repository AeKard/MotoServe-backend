using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class MaintenanceSchedule
{
    public int ScheduleId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Status { get; set; }
}
