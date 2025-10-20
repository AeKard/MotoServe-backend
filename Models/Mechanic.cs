using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Mechanic
{
    public int MechanicId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? PhoneNumber { get; set; }

    public string? MotorExpertise { get; set; }

    public virtual ICollection<MaintenanceHistory> MaintenanceHistories { get; set; } = new List<MaintenanceHistory>();

    public virtual ICollection<MaintenanceType> MaintenanceTypes { get; set; } = new List<MaintenanceType>();

    public virtual ICollection<MechanicAccount> MechanicAccounts { get; set; } = new List<MechanicAccount>();
}
