using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class CustomerMotorcycle
{
    public int MotorcycleId { get; set; }

    public int? CustomerId { get; set; }

    public string? MotorBrand { get; set; }

    public string? MotorModel { get; set; }

    public string? MotorStatus { get; set; }
}
