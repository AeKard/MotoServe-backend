using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class PaymentTable
{
    public int Id { get; set; }

    public string? Invoice { get; set; }

    public string? PaymentStatus { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Due { get; set; }
}
